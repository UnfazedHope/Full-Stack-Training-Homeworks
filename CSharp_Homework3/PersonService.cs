namespace Assignment3;

public class PersonService : IPersonService
{
    public void DisplayPersonInfo(Person person)
    {
        Console.WriteLine($"Name: {person.Name}, Age: {person.CalculateAge()}");
        Console.WriteLine("Addresses:");
        foreach (var address in person.GetAddresses())
        {
            Console.WriteLine(address);
        }
    }
}