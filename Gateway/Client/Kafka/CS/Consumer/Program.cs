using System;
using System.Threading;
using System.Threading.Tasks;

using Confluent.Kafka;

using KC = KafkaConfig;

namespace KafkaConsumer
{
    class Program
    {
        /// <summary>Main</summary>
        /// <param name="args">string[]</param>
        static void Main(string[] args)
        {
            KC.GetConfigParameter.InitConfig();
            KC.GetConfigParameter.GetConfigValues(out string brokerList, out string topic,
                out string connectionString, out string cacertLocation, out string consumerGroup);

            // ConsumerConfig
            var config = new ConsumerConfig
            {
                BootstrapServers = brokerList,
                GroupId = consumerGroup,

                // xxxxx.timeout.ms
                SocketTimeoutMs = 60000,
                SessionTimeoutMs = 30000,

                //SASL
                SecurityProtocol = SecurityProtocol.SaslSsl,
                SaslMechanism = SaslMechanism.Plain,
                SaslUsername = "$ConnectionString",
                SaslPassword = connectionString,
                //SslCaLocation = cacertLocation,

                // Options
                AutoOffsetReset = AutoOffsetReset.Earliest,
                BrokerVersionFallback = "1.0.0",
                //Debug = "security,broker,protocol"
            };

            using (IConsumer<long, string> consumer
                = new ConsumerBuilder<long, string>(config)
                    .SetKeyDeserializer(Deserializers.Int64)
                    .SetValueDeserializer(Deserializers.Utf8).Build())
            {
                // CancelKeyPressイベントの設定
                CancellationTokenSource cts = new CancellationTokenSource();
                Console.CancelKeyPress += (_, e) => {
                    e.Cancel = true;
                    cts.Cancel();
                };

                // 購読
                consumer.Subscribe(topic);
                Console.WriteLine("Consuming messages from topic: " + topic + ", broker(s): " + brokerList);
                Console.WriteLine("To stop a process running as consumer, press [CTRL]-[C].");

                while (true)
                {
                    try
                    {
                        ConsumeResult<long, string> ret = consumer.Consume(cts.Token); // 受信
                        Console.WriteLine($"Received: '{ret.Message.Value}'");
                    }
                    catch (ConsumeException e)
                    {
                        Console.WriteLine($"Consume error: {e.Error.Reason}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error: {e.Message}");
                    }

                    if (cts.IsCancellationRequested) break;
                }
            }
        }
    }
}
