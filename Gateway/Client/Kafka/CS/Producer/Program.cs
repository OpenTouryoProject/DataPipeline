using System;
using System.Threading;
using System.Threading.Tasks;

using Confluent.Kafka;

using KC = KafkaConfig;

namespace KafkaProducer
{
    class Program
    {
        /// <summary>bool</summary>
        static private bool loop = true;
        
        /// <summary>Async Main</summary>
        /// <param name="args">string[]</param>
        /// <returns>Task</returns>
        static async Task Main(string[] args)
        {
            // 初期化
            KC.GetConfigParameter.InitConfig();
            KC.GetConfigParameter.GetConfigValues(out string brokerList, out string topic,
                out string connectionString, out string cacertLocation, out string consumerGroup);

            try
            {
                // ProducerConfig
                ProducerConfig config = new ProducerConfig
                {
                    BootstrapServers = brokerList,

                    //SASL
                    SecurityProtocol = SecurityProtocol.SaslSsl,
                    SaslMechanism = SaslMechanism.Plain,
                    SaslUsername = "$ConnectionString",
                    SaslPassword = connectionString,
                    //SslCaLocation = cacertLocation,

                    // Options
                    //Debug = "security,broker,protocol"
                };

                // ProducerBuilder
                using (IProducer<long, string> producer
                    = new ProducerBuilder<long, string>(config)
                        .SetKeySerializer(Serializers.Int64)
                        .SetValueSerializer(Serializers.Utf8).Build())
                {
                    // CancelKeyPressイベントの設定
                    Console.CancelKeyPress += (s, e) => {
                        Program.loop = false;
                    };
                   
                    Console.WriteLine("Sending messages to topic: " + topic + ", broker(s): " + brokerList);
                    Console.WriteLine("To stop a process running as producer, press [CTRL]-[C].");

                    int x = 0;
                    while(Program.loop)
                    {
                        string msg = string.Format("Sample message #{0} sent at {1}", x, DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss.ffff"));

                        // 送信
                        DeliveryResult<long, string> deliveryReport = await producer.ProduceAsync(
                            topic, new Message<long, string> { Key = DateTime.UtcNow.Ticks, Value = msg });

                        Console.WriteLine(string.Format("Message {0} sent (value: '{1}')", x, msg));

                        x++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("Exception Occurred - {0}", e.Message));
            }
        }
    }
}
