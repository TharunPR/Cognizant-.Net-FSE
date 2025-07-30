using System;
using Confluent.Kafka;

public class ChatConsumer
{
    public static void Run()
    {
        var config = new ConsumerConfig
        {
            GroupId = "chat-consumer-group",
            BootstrapServers = "localhost:9092",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
        consumer.Subscribe("chat-messages");

        Console.WriteLine("Listening for chat messages... (Ctrl+C to exit)");

        while (true)
        {
            var consumeResult = consumer.Consume();
            Console.WriteLine($"[RECEIVED] {consumeResult.Message.Value}");
        }
    }
}
