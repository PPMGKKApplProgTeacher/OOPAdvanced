using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

public class Person : IComparable<Person>, IEnumerable<Person>
{
    private string name;
    private int age;

    // Property
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    // Constructor
    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    // IComparable Implementation
    public int CompareTo(Person other)
    {
        if (other == null) return 1; // If other is null, current instance is greater
        return this.Age.CompareTo(other.Age); // Compare based on Age
    }

    // IEnumerable Implementation
    public IEnumerator<Person> GetEnumerator()
    {
        return new List<Person> { this }.GetEnumerator(); // Return an enumerator for the current instance
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    // Method
    public void Greet()
    {
        Console.WriteLine($"Hello, my name is {name} and I am {age} years old.");
    }

    // Static method
    public static void StaticMethod()
    {
        Console.WriteLine("This is a static method!");
    }
}


// expected Output:

// Class: Person

// Properties:
// - Name (System.String)
// - Age (System.Int32)

// Fields:
// - name (System.String)
// - age (System.Int32)

// Methods:
// - ToString
// - Equals
// - GetHashCode
// - GetType
// - Greet
// - StaticMethod
// - CompareTo
// - GetEnumerator
// - GetEnumerator

// Implemented Interfaces:
// - IComparable`1
// - IEnumerable`1

// Creating an instance of 'Person' using reflection...

// Using reflection to get property values...
// Name: John
// Age: 30

// Modifying properties...

// Updated Values:
// Name: Alice
// Age: 25

// Invoking method 'Greet' using reflection...
// Hello, my name is Alice and I am 25 years old.

// Invoking static method 'StaticMethod' using reflection...
// This is a static method!

// Demonstrating IComparable (Sorting by Age)...
// Before Sorting:
// Name: Alice, Age: 25
// Name: Bob, Age: 30
// Name: Charlie, Age: 20

// After Sorting:
// Name: Charlie, Age: 20
// Name: Alice, Age: 25
// Name: Bob, Age: 30

// Demonstrating IEnumerable (Iterating through Person)...
// Iterating over single person (using IEnumerable):
// Name: Alice, Age: 25

// Reflection Exercise Complete!
