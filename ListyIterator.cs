using System;
using System.Collections;
using System.Collections.Generic;

public class ListyIterator<T> : IEnumerable<T>
{
    private readonly List<T> elements;
    private int currentIndex;

    public ListyIterator(IEnumerable<T> collection)
    {
        if (collection == null)
            throw new ArgumentNullException("Collection cannot be null");
        
        elements = new List<T>(collection);
        currentIndex = 0;
    }

    public bool Move()
    {
        if (HasNext())
        {
            currentIndex++;
            return true;
        }
        return false;
    }

    public bool HasNext()
    {
        return currentIndex < elements.Count - 1;
    }

    public void Print()
    {
        if (elements.Count == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
        Console.WriteLine(elements[currentIndex]);
    }

    public void PrintAll()
    {
        if (elements.Count == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
        Console.WriteLine(string.Join(" ", elements));
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var element in elements)
        {
            yield return element;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}



using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        ListyIterator<string> iterator = null;

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] commandParts = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string command = commandParts[0];

            try
            {
                switch (command)
                {
                    case "Create":
                        iterator = new ListyIterator<string>(commandParts.Skip(1));
                        break;

                    case "Move":
                        Console.WriteLine(iterator.Move());
                        break;

                    case "HasNext":
                        Console.WriteLine(iterator.HasNext());
                        break;

                    case "Print":
                        iterator.Print();
                        break;

                    case "PrintAll":
                        iterator.PrintAll();
                        break;
                        
                    default:
                        Console.WriteLine($"Command \"{command}\" Not Found");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
