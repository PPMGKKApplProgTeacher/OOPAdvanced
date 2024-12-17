using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

// Advanced C# Demonstration of IEnumerable, Iterators, Reflection, and Delegates

// Model for a Zoo Animal
public class ZooAnimal
{
    public string Name { get; set; }
    public string Species { get; set; }

    public ZooAnimal(string name, string species)
    {
        Name = name;
        Species = species;
    }

    public override string ToString() => $"{Name} ({Species})";
}

// ZooCollection implementing IEnumerable
public class ZooCollection : IEnumerable<ZooAnimal>
{
    private List<ZooAnimal> _animals = new List<ZooAnimal>();

    public void AddAnimal(ZooAnimal animal) => _animals.Add(animal);

    // Custom Iterator with Yield
    public IEnumerator<ZooAnimal> GetEnumerator()
    {
        foreach (var animal in _animals)
        {
            yield return animal;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

// Demonstrating Reflection
public static class ReflectionDemo
{
    public static void ShowClassDetails<T>(T obj)
    {
        Type type = obj.GetType();
        Console.WriteLine($"Class: {type.Name}");

        Console.WriteLine("Properties:");
        foreach (var prop in type.GetProperties())
        {
            Console.WriteLine($"  {prop.Name} ({prop.PropertyType.Name})");
        }

        Console.WriteLine("Methods:");
        foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
        {
            Console.WriteLine($"  {method.Name}");
        }
    }
}

// Demonstrating Delegates
public delegate void AnimalNotifier(string message);

public static class DelegateDemo
{
    public static void NotifyAnimalArrival(ZooAnimal animal, AnimalNotifier notifier)
    {
        notifier?.Invoke($"{animal.Name} the {animal.Species} has arrived at the zoo!");
    }
}

// Program demonstrating everything
public class Program
{
    public static void Main(string[] args)
    {
        // ZooCollection with IEnumerable and Iterators
        var zoo = new ZooCollection();
        zoo.AddAnimal(new ZooAnimal("Leo", "Lion"));
        zoo.AddAnimal(new ZooAnimal("Ellie", "Elephant"));
        zoo.AddAnimal(new ZooAnimal("Milo", "Monkey"));

        Console.WriteLine("--- Zoo Animals ---");
        foreach (var animal in zoo)
        {
            Console.WriteLine(animal);
        }

        // Reflection Demo
        Console.WriteLine("\n--- Reflection Demo ---");
        ReflectionDemo.ShowClassDetails(new ZooAnimal("Sample", "Species"));

        // Delegate Demo
        Console.WriteLine("\n--- Delegate Demo ---");
        AnimalNotifier notifier = message => Console.WriteLine($"[Notification]: {message}");
        DelegateDemo.NotifyAnimalArrival(new ZooAnimal("Ellie", "Elephant"), notifier);

        Console.WriteLine("\n--- Algorithm Demo: Simple Search ---");
        // Beginner Algorithm: Simple Search
        string searchSpecies = "Monkey";
        var foundAnimal = FindAnimalBySpecies(zoo, searchSpecies);
        Console.WriteLine(foundAnimal != null
            ? $"Found: {foundAnimal}"
            : $"No animal of species {searchSpecies} found.");
    }

    // Beginner Algorithm: Find Animal by Species
    public static ZooAnimal FindAnimalBySpecies(ZooCollection zoo, string species)
    {
        foreach (var animal in zoo)
        {
            if (animal.Species == species)
                return animal;
        }
        return null;
    }
}

