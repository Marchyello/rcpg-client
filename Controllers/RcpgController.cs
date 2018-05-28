using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Rcpg;
using RcpgMicroserviceClient.Entities;
using RcpgMicroserviceClient.Models;
using RcpgMicroserviceClient.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using static RcpgMicroserviceClient.Models.ErrorType;
using static System.String;


namespace RcpgMicroserviceClient.Controllers
{
    public class RcpgController : Controller
    {
        private readonly Channel channel;
        private readonly IRcpgClient rcpgClient;
        private readonly IPaymentRepository paymentRepository;
        private const string DEFAULT_CURRENCY = "EUR";
        private const string CONFIRM_RETURN_URL = "http://127.0.0.1:5000/Rcpg/PayCardless";
        private const string CANCELED_RETURN_URL = "http://127.0.0.1:5000/Rcpg/CanceledReturn";

        public RcpgController(Channel channel, IRcpgClient rcpgClient, IPaymentRepository paymentRepository)
        {
            this.channel = channel;
            this.rcpgClient = rcpgClient;
            this.paymentRepository = paymentRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewPayment()
        {
            return View();
        }

        public async Task<IActionResult> CanceledReturn([FromQuery] string token)
        {
            TempData["actionInitiated"] = true;

            if (string.IsNullOrEmpty(token))
            {
                setError(EmptyReturnParam);
                return redirectToLandingPage();
            }

            var payment = await paymentRepository.Track(token);
            if (payment == null)
            {
                setError(PaymentNotFound);
                return redirectToLandingPage();
            }

            // Can only cancel a payment that has been initiated.
            if (Enum.Parse<PaymentStatus>(payment.Status) != PaymentStatus.Initiated)
            {
                setError(NotCancelable);
                return redirectToLandingPage();
            }

            payment.Status = PaymentStatus.Canceled.ToString();
            await paymentRepository.Update(payment);

            TempData["notificationText"] = $"Maksājums ar marķieri: \"{token}\" ir atcelts";
            return redirectToAllPayments();
        }

        public async Task<IActionResult> PayCardless([FromQuery] string token, [FromQuery] string PayerID)
        {
            TempData["actionInitiated"] = true;

            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(PayerID))
            {
                setError(EmptyReturnParam);
                return redirectToLandingPage();
            }

            var payment = await paymentRepository.Track(token);
            if (payment == null)
            {
                setError(PaymentNotFound);
                return redirectToLandingPage();
            }
            PayResponse response = await rcpgClient.PayCardless(PayerID, payment);

            if (response.PaymentErrors.Any())
            {
                TempData["hasErrors"] = true;
                TempData["notificationText"] = $"Notikusi kļūda. Kļūdas avots: \"{response.PaymentErrors.First().Source}\", kļūdas kods: \"{response.PaymentErrors.First().ErrorCode}\"";
                return redirectToLandingPage();
            }

            if (Enum.Parse<Intent>(payment.Intent) == Intent.Purchase)
            {
                payment.Status = PaymentStatus.Captured.ToString();
                payment.CapturedOn = DateTime.Parse(response.ExecutedOn);
            }
            else
            {
                payment.Status = PaymentStatus.Authorized.ToString();   
            }
            payment.TransactionId = response.PaymentId;

            await paymentRepository.Update(payment);

            TempData["notificationText"] = $"Veiksmīgs maksājums ar transakcijas identifikatoru: \"{response.PaymentId}\"";
            return redirectToAllPayments();
        }

        [HttpPost]
        public async Task<IActionResult> PayStandard(Provider provider, int paymentSum, PaymentCard paymentCard, Intent intent)
        {
            TempData["actionInitiated"] = true;
            if (intent == Intent.NoIntent)
            {
                setError(InvalidIntent);
                return redirectToLandingPage();
            }

            // Let's assume payment sum and payment card gets validated on the client side, so no need to do it here.

            PayResponse response = await rcpgClient.PayStandard(provider, paymentSum, DEFAULT_CURRENCY, paymentCard, intent);

            if (response.PaymentErrors.Any())
            {
                TempData["hasErrors"] = true;
                TempData["notificationText"] = $"Notikusi kļūda. Kļūdas avots: \"{response.PaymentErrors.First().Source}\", kļūdas kods: \"{response.PaymentErrors.First().ErrorCode}\"";
                return redirectToLandingPage();
            }

            Payment payment = new Payment()
            {
                Token = response.PaymentId,
                Sum = paymentSum,
                Currency = DEFAULT_CURRENCY,
                Provider = provider.ToString(),
                Intent = intent.ToString(),
                TransactionId = response.PaymentId,
                InitiatedOn = DateTime.Parse(response.ExecutedOn)
            };
            if (intent == Intent.Purchase)
            {
                payment.Status = PaymentStatus.Captured.ToString();
                payment.CapturedOn = DateTime.Parse(response.ExecutedOn);
            }
            else
            {
                payment.Status = PaymentStatus.Authorized.ToString();
            }
            await paymentRepository.Add(payment);

            return redirectToAllPayments();
        }

        [HttpPost]
        public async Task<IActionResult> CapturePayment(string transactionId)
        {
            TempData["actionInitiated"] = true;
            if (string.IsNullOrEmpty(transactionId))
            {
                setError(EmptyTransactionId);
                return redirectToLandingPage();
            }

            var payment = await paymentRepository.TrackByTransactionId(transactionId);
            if (payment == null)
            {
                setError(PaymentNotFound);
                return redirectToLandingPage();
            }

            PayResponse response = await rcpgClient.Capture(payment);

            if (response.PaymentErrors.Any())
            {
                TempData["notificationText"] = $"Notikusi kļūda. Kļūdas avots: \"{response.PaymentErrors.First().Source}\", kļūdas kods: \"{response.PaymentErrors.First().ErrorCode}\"";
                return redirectToLandingPage();
            }

            payment.Status = PaymentStatus.Captured.ToString();
            payment.TransactionId = response.PaymentId;
            payment.CapturedOn = DateTime.Parse(response.ExecutedOn);
            
            await paymentRepository.Update(payment);

            TempData["notificationText"] = $"Veiksmīga nokārtošana ar identifikatoru: \"{response.PaymentId}\"";
            return redirectToAllPayments();
        }

        public async Task<IActionResult> AllPayments()
        {
            return View(await paymentRepository.GetAll());
        }

        public async Task<IActionResult> Details(string id)
        {
            TempData["actionInitiated"] = true;

            var payment = await paymentRepository.Find(id);
            var provider = Enum.Parse<Provider>(payment.Provider);
            var identifier = payment.TransactionId ?? payment.Token;
            PaymentIdType idType = payment.TransactionId == null ? PaymentIdType.Token : PaymentIdType.TransactionId;
            
            GetDetailsResponse response = await rcpgClient.GetDetails(provider, identifier, idType);

            if (response.Errors.Any())
            {
                TempData["hasErrors"] = true;
                TempData["notificationText"] = $"Notikusi kļūda. Kļūdas avots: \"{response.Errors.First().Source}\", kļūdas kods: \"{response.Errors.First().ErrorCode}\"";
                return redirectToLandingPage();
            }

            string json = JObject.Parse(response.Details).ToString(Formatting.Indented);
            return View("Details", json);
        }

        [HttpPost]
        public async Task<IActionResult> InitiateCardless(Provider provider, int paymentSum, Intent intent)
        {
            TempData["actionInitiated"] = true;
            if (intent == Intent.NoIntent)
            {
                setError(InvalidIntent);
                return redirectToLandingPage();
            }

            InitiateCardlessResponse response = await rcpgClient.InitiateCardless(provider, intent, paymentSum, DEFAULT_CURRENCY, CONFIRM_RETURN_URL, CANCELED_RETURN_URL);

            if (response.PaymentErrors.Any())
            {
                TempData["hasErrors"] = true;
                TempData["notificationText"] = $"Notikusi kļūda. Kļūdas avots: \"{response.PaymentErrors.First().Source}\", kļūdas kods: \"{response.PaymentErrors.First().ErrorCode}\"";
                return redirectToLandingPage();
            }

            Payment payment = new Payment()
            {
                Token = response.Token,
                Sum = paymentSum,
                Currency = DEFAULT_CURRENCY,
                Provider = provider.ToString(),
                Intent = intent.ToString(),
                Status = PaymentStatus.Initiated.ToString(),
                InitiatedOn = DateTime.Parse(response.InitiatedOn)
            };
            await paymentRepository.Add(payment);

            // Redirects to provider where buyer can either confirm or cancel purchase.
            return Redirect(response.ConfirmInitiationUrl);
        }

        [HttpPost]
        public async Task<IActionResult> ShutdownChannel()
        {
            TempData["actionInitiated"] = true;

            await rcpgClient.ShutdownChannel();

            TempData["notificationText"] = "gRPC kanāls slēgts";
            return redirectToLandingPage();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void setError(ErrorType errorType)
        {
            this.TempData["hasErrors"] = true;
            switch (errorType)
            {
                case EmptyReturnParam:
                    TempData["notificationText"] = "Tukšs obligātais parametrs";
                    break;
                case EmptyTransactionId:
                    TempData["notificationText"] = "Maksājums nav apstiprināts";
                    break;
                case InvalidIntent:
                    TempData["notificationText"] = "Nederīgs nolūks";
                    break;
                case NotCancelable:
                    TempData["notificationText"] = "Maksājumu nevar atcelt";
                    break;
                case PaymentNotFound:
                    TempData["notificationText"] = "Maksājums nav atrasts";
                    break;
                default:
                    throw new ArgumentException("Invalid error type");
            }
        }

        private IActionResult redirectToLandingPage() => RedirectToAction("Index");

        private IActionResult redirectToAllPayments() => RedirectToAction("AllPayments");
    }
}
