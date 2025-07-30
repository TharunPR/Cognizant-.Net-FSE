using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Select mode: [1] Producer, [2] Consumer");
        var choice = Console.ReadLine();

        if (choice == "1")
        {
            await ChatProducer.Run();
        }
        else if (choice == "2")
        {
            ChatConsumer.Run();
        }
        else
        {
            Console.WriteLine("Invalid option.");
        }
    }
}
