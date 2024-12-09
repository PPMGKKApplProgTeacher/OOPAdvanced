class Program
{
    static void Main(string[] args)
    {
        // Create an instance of Investigator
        Investigator investigator = new Investigator();

        // Define the class to investigate and the fields to inspect
        string className = "Agent";
        string[] fieldNames = { "SecretCode", "Mission" };

        // Investigate the class
        investigator.Investigate(className, fieldNames);
    }
}
