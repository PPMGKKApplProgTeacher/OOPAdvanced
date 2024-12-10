public class Target
{
    public string PublicInfo = "PublicData";
    private string PrivateInfo = "SecretData";

    public int PublicId { get; set; }
    private double PrivateBalance { get; set; }

    public Target()
    {
        this.PublicId = 42;
        this.PrivateBalance = 1000.50;
    }

    public string GetPublicInfo()
    {
        return this.PublicInfo;
    }

    private string GetPrivateInfo()
    {
        return this.PrivateInfo;
    }

    private void UpdateBalance(double amount)
    {
        this.PrivateBalance += amount;
    }
}


Exercise 1: Steal Field Info

Task: Implement a method that retrieves and prints the value of PublicInfo and PrivateInfo.
Solution

Spy spy = new Spy();
Console.WriteLine(spy.StealFieldInfo("Target", "PublicInfo", "PrivateInfo"));

Expected Output:

Class under investigation: Target
PublicInfo = PublicData
PrivateInfo = SecretData

Exercise 2: Analyze Access Modifiers

Task: Verify the access modifiers of the Target class fields and methods.
Solution

Console.WriteLine(spy.AnalyzeAccessModifiers("Target"));

Expected Output:

PublicInfo must be private!
get_PublicId have to be public!
set_PublicId have to be private!
get_PrivateBalance have to be public!
set_PrivateBalance have to be private!

Exercise 3: Reveal Private Methods

Task: List all private methods in the Target class.
Solution

Console.WriteLine(spy.RevealPrivateMethods("Target"));

Expected Output:

All Private Methods of Class: Target
Base Class: Object
GetPrivateInfo
UpdateBalance
Finalize
MemberwiseClone

Exercise 4: Collect Getters and Setters

Task: Identify getters and setters in the Target class, along with their return and parameter types.
Solution

Console.WriteLine(spy.CollectGettersAndSetters("Target"));

Expected Output:

get_PublicId will return System.Int32
get_PrivateBalance will return System.Double
set_PublicId will set field of System.Int32
set_PrivateBalance will set field of System.Double
