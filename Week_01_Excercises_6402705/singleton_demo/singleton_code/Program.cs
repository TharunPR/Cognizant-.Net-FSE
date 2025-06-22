public class Singleton
{
    private static Singleton _instance;
    private static readonly object _lock = new();

    private Singleton()
    {
        Console.WriteLine("[Singleton] Instance Created");
    }

    public static Singleton GetInstance()
    {
        lock (_lock)
        {
            if (_instance == null)
                _instance = new Singleton();
            else
                Console.WriteLine("[Singleton] Existing instance reused");
        }
        return _instance;
    }

    public void ShowMessage()
    {
        Console.WriteLine("[Singleton] Hello from Singleton!");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("--- Singleton Pattern ---");
        var s1 = Singleton.GetInstance();
        s1.ShowMessage();

        var s2 = Singleton.GetInstance();
        Console.WriteLine($"Are s1 and s2 the same instance? {ReferenceEquals(s1, s2)}");
    }
}
