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
