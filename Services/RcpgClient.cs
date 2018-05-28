using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using Rcpg;
using RcpgMicroserviceClient.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RcpgMicroserviceClient.Services
{
    public interface IRcpgClient
    {
        Task<InitiateCardlessResponse> InitiateCardless(Provider provider, Intent intent, int paymentSum, string currency, string returnUrl, string cancelUrl);
        Task<PayResponse> PayStandard(Provider provider, int paymentSum, string currency, PaymentCard paymentCard, Intent intent);
        Task<PayResponse> PayCardless(string payerId, Payment payment);
        Task<PayResponse> Capture(Payment payment);
        Task<GetDetailsResponse> GetDetails(Provider provider, string id, PaymentIdType idType);
        Task ShutdownChannel();
    }

    public class RcpgClient : IRcpgClient
    {
        private readonly Channel channel;
        private readonly DbContextOptions<RcpgClientDbContext> dbContextOptions;
        private readonly PaymentGatewayGrpc.PaymentGatewayGrpcClient client;
        public bool IsConnected { get { return this.channel.State != ChannelState.Shutdown; } }

        public RcpgClient(Channel channel, DbContextOptions<RcpgClientDbContext> options)
        {
            this.channel = channel;
            this.dbContextOptions = options;
            this.client = new PaymentGatewayGrpc.PaymentGatewayGrpcClient(channel);
        }

        public async Task<InitiateCardlessResponse> InitiateCardless(Provider provider, Intent intent, int paymentSum, string currency, string returnUrl, string cancelUrl)
        {
            if (channel.State == ChannelState.Shutdown)
            {
                var response = new InitiateCardlessResponse();
                response.PaymentErrors.Add(setClientShutDownError());
                return response;
            }

            InitiateCardlessRequest request = new InitiateCardlessRequest()
            {
                Provider = provider,
                Intent = intent,
                PaymentSum = paymentSum,
                ReturnUrl = returnUrl,
                CancelReturnUrl = cancelUrl,
                Currency = currency,
                AllowGuestCheckout = true // Allows/disallows buyers that are not registered in providers service.
            };

            // Dummy item list. Total sum of items must be equal to paymentSum.
            var items = new List<Item>()
            {
                new Item()
                {
                    Name = "Bike",
                    Description = "A brand new bike!",
                    Quantity = 1,
                    Amount = paymentSum
                }
            };
            request.Items.AddRange(items);

            try
            {
                return await client.InitiateCardlessAsync(request);
            }
            catch (RpcException ex)
            {
                var response = new InitiateCardlessResponse();
                response.PaymentErrors.Add(setGatewayError(ex.Message));
                return response;
            }
        }

        public async Task<PayResponse> PayStandard(Provider provider, int paymentSum, string currency, PaymentCard paymentCard, Intent intent)
        {
            if (channel.State == ChannelState.Shutdown)
            {
                var response = new PayResponse();
                response.PaymentErrors.Add(setClientShutDownError());
                return response;
            }

            PayStandardRequest request = new PayStandardRequest()
            {
                Provider = provider,
                PaymentSum = paymentSum,
                Currency = currency,
                PaymentCard = paymentCard,
                Intent = intent
            };

            // Dummy item list. Total sum of items must be equal to paymentSum.
            var items = new List<Item>()
            {
                new Item()
                {
                    Name = "A hat",
                    Description = "And a cat in that hat!",
                    Quantity = 1,
                    Amount = paymentSum
                }
            };
            request.Items.AddRange(items);

            try
            {
                return await client.PayStandardAsync(request);
            }
            catch (RpcException ex)
            {
                var response = new PayResponse();
                response.PaymentErrors.Add(setGatewayError(ex.Message));
                return response;
            }
        }

        public async Task<PayResponse> PayCardless(string payerId, Payment payment)
        {
            if (channel.State == ChannelState.Shutdown)
            {
                var response = new PayResponse();
                response.PaymentErrors.Add(setClientShutDownError());
                return response;
            }

            PayCardlessRequest request = new PayCardlessRequest()
            {
                Provider = Enum.Parse<Provider>(payment.Provider),
                PaymentSum = payment.Sum,
                Currency = payment.Currency,
                PaymentId = payment.Token,
                PayerId = payerId,
                Intent = Enum.Parse<Intent>(payment.Intent)
            };

            try
            {
                return await client.PayCardlessAsync(request);
            }
            catch (RpcException ex)
            {
                var response = new PayResponse();
                response.PaymentErrors.Add(setGatewayError(ex.Message));
                return response;
            }
        }

        public async Task<PayResponse> Capture(Payment payment)
        {
            if (channel.State == ChannelState.Shutdown)
            {
                var response = new PayResponse();
                response.PaymentErrors.Add(setClientShutDownError());
                return response;
            }

            CaptureRequest request = new CaptureRequest()
            {
                Provider = Enum.Parse<Provider>(payment.Provider),
                PaymentSum = payment.Sum,
                Currency = payment.Currency,
                PaymentId = payment.TransactionId
            };

            try
            {
                return await client.CaptureAsync(request);
            }
            catch (RpcException ex)
            {
                var response = new PayResponse();
                response.PaymentErrors.Add(setGatewayError(ex.Message));
                return response;
            }
        }

        public async Task<GetDetailsResponse> GetDetails(Provider provider, string id, PaymentIdType idType)
        {
            if (channel.State == ChannelState.Shutdown)
            {
                var response = new GetDetailsResponse();
                response.Errors.Add(setClientShutDownError());
                return response;
            }

            GetDetailsRequest request = new GetDetailsRequest()
            {
                Provider = provider,
                Identifier = id,
                IdType = idType
            };

            try
            {
                return await client.GetDetailsAsync(request);
            }
            catch (RpcException ex)
            {
                var response = new GetDetailsResponse();
                response.Errors.Add(setGatewayError(ex.Message));
                return response;
            }
        }

        public async Task ShutdownChannel()
        {
            if (channel.State != ChannelState.Shutdown)
            {
                Console.WriteLine("--- gRPC channel is being shutdown ---");
                await channel.ShutdownAsync();
            }
        }

        private PaymentError setGatewayError(string errorCode)
        {
            return new PaymentError()
            {
                Source = "payment_gateway",
                ErrorCode = errorCode
            };
        }

        private PaymentError setClientShutDownError()
        {
            return new PaymentError()
            {
                Source = "client_channel",
                ErrorCode = "shut_down"
            };
        }
    }
}