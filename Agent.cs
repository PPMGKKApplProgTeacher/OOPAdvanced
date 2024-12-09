public class Agent
{
    public string Name = "James Bond";
    private string SecretCode = "007";
    private string Mission = "Top Secret Mission";
    public int Age = 35;

    public void PrintDetails()
    {
        Console.WriteLine($"Agent: {Name}, Age: {Age}");
    }
}
