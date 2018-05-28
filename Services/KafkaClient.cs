using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RcpgMicroserviceClient.Services
{
    public interface IKafkaClient
    {
       string ConsumeInitiatePayment(string topic);
    }

    public class KafkaClient : IKafkaClient
    {
        private readonly Consumer<Null, string> consumer;

        public KafkaClient()
        {
            var consumerConfig = new Dictionary<string, object>
            {
                { "group.id", "rcpg-client-consumer-group" },
                { "bootstrap.servers", "localhost:9092" },
                { "auto.commit.interval.ms", 5000 },
                { "auto.offset.reset", "smallest" }
            };

            this.consumer = new Consumer<Null, string>(consumerConfig, null, new StringDeserializer(Encoding.UTF8));

            var subscriptions = new List<string>(){ "RCPG_log", "RCPG_capture_results"};
            consumer.Subscribe(subscriptions);
        }

        public string ConsumeInitiatePayment(string topic)
        {
            bool canStop = false;
            string result = null;

            consumer.OnMessage += (_, msg) =>
            {
                // Consume only from chosen topic.
                if (msg.Topic == topic)
                {
                    result += "\n---START OF MESSAGE---";
                    result += msg.Value;
                    result += "\n---END OF MESSAGE---";
                }

                // If a message was consumed, continue.
                canStop = true;
            };

            while (!canStop)
            {
                // Only stops polling if all messages were consumed.
                canStop = true;
                
                consumer.Poll(100);
            }

            return result;
        }
    }
}