public abstract class Product
{
    public abstract string GetDetails();
}

public class Book : Product
{
    public override string GetDetails() => "[Product] This is a BOOK.";
}

public class Laptop : Product
{
    public override string GetDetails() => "[Product] This is a LAPTOP.";
}

public abstract class ProductFactory
{
    public abstract Product CreateProduct();
}

public class BookFactory : ProductFactory
{
    public override Product CreateProduct()
    {
        Console.WriteLine("[Factory] Creating a Book...");
        return new Book();
    }
}

public class LaptopFactory : ProductFactory
{
    public override Product CreateProduct()
    {
        Console.WriteLine("[Factory] Creating a Laptop...");
        return new Laptop();
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("--- Factory Method Pattern ---");

        ProductFactory bookFactory = new BookFactory();
        Product book = bookFactory.CreateProduct();
        Console.WriteLine(book.GetDetails());

        ProductFactory laptopFactory = new LaptopFactory();
        Product laptop = laptopFactory.CreateProduct();
        Console.WriteLine(laptop.GetDetails());
    }
}
