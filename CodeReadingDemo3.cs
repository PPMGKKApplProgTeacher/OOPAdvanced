using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("--- While Loop Examples ---");
        int counter = 0;
        while (counter < 5)
        {
            Console.WriteLine($"Counter: {counter}");
            if (counter == 3)
            {
                Console.WriteLine("Breaking at 3");
                break;
            }
            counter++;
        }

        counter = 0;
        while (counter < 5)
        {
            counter++;
            if (counter == 2)
            {
                Console.WriteLine("Skipping 2");
                continue;
            }
            Console.WriteLine($"Counter: {counter}");
        }

        counter = 0;
        while (counter < 3)
        {
            try
            {
                if (counter == 1)
                {
                    throw new Exception("Error at 1");
                }
                Console.WriteLine($"Counter: {counter}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            finally
            {
                counter++;
            }
        }

        Console.WriteLine("\n--- For Loop Examples ---");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Index: {i}");
            if (i == 3)
            {
                Console.WriteLine("Breaking at 3");
                break;
            }
        }

        for (int i = 0; i < 5; i++)
        {
            if (i == 2)
            {
                Console.WriteLine("Skipping 2");
                continue;
            }
            Console.WriteLine($"Index: {i}");
        }

        Console.WriteLine("\n--- Foreach Loop Examples ---");
        var numbers = new[] { 1, 2, 3, 4, 5 };
        foreach (var number in numbers)
        {
            if (number == 3)
            {
                Console.WriteLine("Breaking at 3");
                break;
            }
            Console.WriteLine($"Number: {number}");
        }

        foreach (var number in numbers)
        {
            if (number == 2)
            {
                Console.WriteLine("Skipping 2");
                continue;
            }
            Console.WriteLine($"Number: {number}");
        }

        Console.WriteLine("\n--- Conditional Statements with Loops ---");
        foreach (var number in numbers)
        {
            if (number < 3)
            {
                Console.WriteLine($"Number {number} is less than 3.");
            }
            else if (number == 3)
            {
                Console.WriteLine("Number is exactly 3.");
            }
            else
            {
                Console.WriteLine($"Number {number} is greater than 3.");
            }
        }

        Console.WriteLine("\n--- Nested Loops and Exception Handling ---");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                try
                {
                    if (i == 1 && j == 1)
                    {
                        throw new Exception("Error at (1, 1)");
                    }
                    Console.WriteLine($"Coordinates: ({i}, {j})");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
            }
        }
    }
}

