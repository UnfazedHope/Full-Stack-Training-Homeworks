namespace Assignment3;

public class Person
{
    // Encapsulation
    private List<string> addresses = new List<string>();
    public decimal Salary { get; set; }

    public string Name { get; set; }
    
    public DateTime BirthDate { get; set; }

    public int CalculateAge()
    {
        return DateTime.Now.Year - BirthDate.Year;
    }

    public void AddAddress(string address)
    {
        addresses.Add(address);
    }

    public List<string> GetAddresses()
    {
        return addresses;
    }

    // Polymorphism using virtual method
    public virtual decimal CalculateSalary()
    {
        return Salary;
    }
}