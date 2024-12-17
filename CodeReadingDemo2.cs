using System;
using System.Collections.Generic;
using System.Linq;

// Model: Represents a simple User
public class User
{
    public string Name { get; set; }
    public int Age { get; set; }

    public User(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public override string ToString() => $"{Name}, Age: {Age}";
}

// Manager class showcasing various functionalities
public class UserManager
{
    private List<User> _users = new List<User>();

    // Add a user to the system
    public void AddUser(User user)
    {
        if (_users.Any(u => u.Name == user.Name))
        {
            throw new InvalidOperationException($"User {user.Name} already exists.");
        }
        _users.Add(user);
        Console.WriteLine($"User {user.Name} added successfully.");
    }

    // Find the oldest user
    public User FindOldestUser()
    {
        if (!_users.Any())
        {
            throw new InvalidOperationException("No users found in the system.");
        }
        return _users.OrderByDescending(u => u.Age).First();
    }

    // Filter users by a minimum age
    public List<User> GetUsersAboveAge(int minAge)
    {
        return _users.Where(u => u.Age >= minAge).ToList();
    }

    // List all users
    public void ListAllUsers()
    {
        if (_users.Count == 0)
        {
            Console.WriteLine("No users in the system.");
        }
        else
        {
            foreach (var user in _users)
            {
                Console.WriteLine(user);
            }
        }
    }

    // Remove a user by name
    public void RemoveUser(string name)
    {
        var user = _users.FirstOrDefault(u => u.Name == name);
        if (user == null)
        {
            Console.WriteLine($"User {name} not found.");
        }
        else
        {
            _users.Remove(user);
            Console.WriteLine($"User {name} removed successfully.");
        }
    }
}

public class Program
{
    public static void Main()
    {
        var userManager = new UserManager();

        // Adding users
        try
        {
            userManager.AddUser(new User("Alice", 25));
            userManager.AddUser(new User("Bob", 30));
            userManager.AddUser(new User("Charlie", 20));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("\n--- All Users ---");
        userManager.ListAllUsers();

        // Find the oldest user
        Console.WriteLine("\n--- Oldest User ---");
        try
        {
            var oldest = userManager.FindOldestUser();
            Console.WriteLine($"Oldest User: {oldest}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        // Filter users above a certain age
        Console.WriteLine("\n--- Users Above Age 22 ---");
        var adults = userManager.GetUsersAboveAge(22);
        if (adults.Count == 0)
        {
            Console.WriteLine("No users found above age 22.");
        }
        else
        {
            foreach (var user in adults)
            {
                Console.WriteLine(user);
            }
        }

        // Remove a user
        Console.WriteLine("\n--- Removing User: Bob ---");
        userManager.RemoveUser("Bob");
        Console.WriteLine("\n--- All Users After Removal ---");
        userManager.ListAllUsers();

        // Exception handling for adding duplicates
        Console.WriteLine("\n--- Adding Duplicate User: Alice ---");
        try
        {
            userManager.AddUser(new User("Alice", 25));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        // Exception handling for oldest user in empty system
        Console.WriteLine("\n--- Removing All Users and Finding Oldest ---");
        userManager.RemoveUser("Alice");
        userManager.RemoveUser("Charlie");
        try
        {
            var oldest = userManager.FindOldestUser();
            Console.WriteLine($"Oldest User: {oldest}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

