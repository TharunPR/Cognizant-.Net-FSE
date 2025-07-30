using System;
using System.Threading.Tasks;
using Confluent.Kafka;

public class ChatProducer
{
    public static async Task Run()
    {
        var config = new ProducerConfig
        {
            BootstrapServers = "localhost:9092"
        };

        using var producer = new ProducerBuilder<Null, string>(config).Build();

        Console.Write("Enter your name: ");
        var name = Console.ReadLine();

        Console.WriteLine("Type messages (type 'exit' to quit):");

        while (true)
        {
            var message = Console.ReadLine();
            if (message?.ToLower() == "exit") break;

            var result = await producer.ProduceAsync("chat-messages", new Message<Null, string>
            {
                Value = $"{name}: {message}"
            });

            Console.WriteLine($"[SENT] {result.Value}");
        }
    }
}
