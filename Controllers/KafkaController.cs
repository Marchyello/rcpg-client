using Microsoft.AspNetCore.Mvc;
using RcpgMicroserviceClient.Services;
using System;
using System.Threading.Tasks;

namespace RcpgMicroserviceClient.Controllers
{
    public class KafkaController : Controller
    {
        private readonly IKafkaClient kafkaUtil;
    
        public KafkaController(IKafkaClient kafkaUtil)
        {
            this.kafkaUtil = kafkaUtil;
        }

        public IActionResult Kafka()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ConsumeLogs(string topic)
        {
            string result = kafkaUtil.ConsumeInitiatePayment(topic);
            return View("Kafka", result);
        }
    }
}