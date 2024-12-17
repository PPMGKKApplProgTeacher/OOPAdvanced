using System;

// Interface for common properties
public interface IPerson
{
    string FirstName { get; set; }
    string LastName { get; set; }
    decimal Discount { get; }
}

// Main DiscountHandler class
public class DiscountHandler
{
    public void CalculateDiscount(
        Action<string> NotifyUser, 
        Func<decimal, decimal> CalculateDiscount, 
        Predicate<string> CheckExistingCustomer, 
        string id, 
        decimal price)
    {
        if (!CheckExistingCustomer(id))
        {
            Console.WriteLine("[Error] Customer not found or not eligible.");
            return;
        }

        decimal discountedPrice = CalculateDiscount(price);
        NotifyUser($"Discount applied! Final price: {discountedPrice:C}");
    }
}

// Adult class
public class Adult : IPerson
{
    private DiscountHandler _discountHandler = new DiscountHandler();

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal Discount => 0.1m; // 10% discount

    public string ID { get; set; }

    // Named functions
    public void ApplyDiscount_Named()
    {
        Action<string> NotifyUser = NotifyUserMethod;
        Func<decimal, decimal> CalculateDiscount = CalculateDiscountMethod;
        Predicate<string> CheckExistingCustomer = CheckExistingCustomerMethod;

        _discountHandler.CalculateDiscount(NotifyUser, CalculateDiscount, CheckExistingCustomer, ID, 100m);
    }

    private void NotifyUserMethod(string message) => Console.WriteLine($"{FirstName} {LastName} enters the zoo. {message}");
    private decimal CalculateDiscountMethod(decimal price) => price * (1 - Discount);
    private bool CheckExistingCustomerMethod(string id)
    {
        Console.WriteLine($"[Adult] Client's ID is {id}");
        return true; // Simulated check
    }

    // Anonymous functions
    public void ApplyDiscount_Anonymous()
    {
        _discountHandler.CalculateDiscount(
            message => Console.WriteLine($"{FirstName} {LastName} enters the zoo. {message}"),
            price => price * (1 - Discount),
            id =>
            {
                Console.WriteLine($"[Adult] Client's ID is {id}");
                return true; // Simulated check
            },
            ID,
            100m
        );
    }
}

// Child class
public class Child : IPerson
{
    private DiscountHandler _discountHandler = new DiscountHandler();

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal Discount => 0.2m; // 20% discount

    public Adult Parent { get; set; }

    // Named functions
    public void ApplyDiscount_Named()
    {
        Action<string> NotifyUser = NotifyUserMethod;
        Func<decimal, decimal> CalculateDiscount = CalculateDiscountMethod;
        Predicate<string> CheckExistingCustomer = CheckExistingCustomerMethod;

        _discountHandler.CalculateDiscount(NotifyUser, CalculateDiscount, CheckExistingCustomer, Parent.ID, 50m);
    }

    private void NotifyUserMethod(string message) => Console.WriteLine($"Little {FirstName} enters the zoo. {message}");
    private decimal CalculateDiscountMethod(decimal price) => price * (1 - Discount);
    private bool CheckExistingCustomerMethod(string parentId)
    {
        Console.WriteLine($"[Child] Client's parent's ID is {parentId}");
        return true; // Simulated check
    }

    // Anonymous functions
    public void ApplyDiscount_Anonymous()
    {
        _discountHandler.CalculateDiscount(
            message => Console.WriteLine($"Little {FirstName} enters the zoo. {message}"),
            price => price * (1 - Discount),
            parentId =>
            {
                Console.WriteLine($"[Child] Client's parent's ID is {parentId}");
                return true; // Simulated check
            },
            Parent.ID,
            50m
        );
    }
}

// Test the implementation
public class Program
{
    public static void Main(string[] args)
    {
        Adult adult = new Adult { FirstName = "John", LastName = "Doe", ID = "AdultID123" };
        Console.WriteLine("--- Adult Named ---");
        adult.ApplyDiscount_Named();

        Console.WriteLine("\n--- Adult Anonymous ---");
        adult.ApplyDiscount_Anonymous();

        Child child = new Child { FirstName = "Timmy", LastName = "Doe", Parent = adult };
        Console.WriteLine("\n--- Child Named ---");
        child.ApplyDiscount_Named();

        Console.WriteLine("\n--- Child Anonymous ---");
        child.ApplyDiscount_Anonymous();
    }
}

