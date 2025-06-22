public class FinancialData
{
    public int Year { get; set; }
    public decimal Revenue { get; set; }
}

public class Forecasting
{
    public decimal CalculateAverageGrowthRate(List<FinancialData> data)
    {
        decimal totalGrowth = 0;
        for (int i = 1; i < data.Count; i++)
        {
            var growth = (data[i].Revenue - data[i - 1].Revenue) / data[i - 1].Revenue;
            Console.WriteLine($"Growth from {data[i - 1].Year} to {data[i].Year}: {growth:P2}");
            totalGrowth += growth;
        }
        return totalGrowth / (data.Count - 1);
    }

    public decimal ForecastRevenue(decimal lastRevenue, decimal growthRate, int years)
    {
        return lastRevenue * (decimal)Math.Pow((double)(1 + growthRate), years);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("--- Financial Forecasting ---");

        var data = new List<FinancialData>
        {
            new() { Year = 2021, Revenue = 100000 },
            new() { Year = 2022, Revenue = 120000 },
            new() { Year = 2023, Revenue = 144000 }
        };

        foreach (var d in data)
            Console.WriteLine($"Year {d.Year}: Revenue = ₹{d.Revenue:N0}");

        var forecasting = new Forecasting();
        var avgGrowth = forecasting.CalculateAverageGrowthRate(data);
        var forecast2025 = forecasting.ForecastRevenue(data.Last().Revenue, avgGrowth, 2);

        Console.WriteLine($"\nAverage Growth Rate: {avgGrowth:P2}");
        Console.WriteLine($"Projected Revenue for 2025: ₹{forecast2025:N0}");
    }
}
