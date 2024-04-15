using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KafkaConsumer
{
    public class Consumer
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hii");
            var config = new ConsumerConfig
            {
                GroupId = "gid-consumers",
                BootstrapServers = "localhost:9092"
            };
            using (var consumer = new ConsumerBuilder<Null, string>(config).Build())
            {
                consumer.Subscribe("test55");
                while (true)
                {
                    var cr = consumer.Consume();
                    Console.WriteLine(cr.Message.Value);
                }

            }
        }
    }
}
