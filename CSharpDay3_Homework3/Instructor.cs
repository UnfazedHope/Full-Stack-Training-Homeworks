namespace Assignment3;

public class Instructor : Person
{
    public Department Department { get; set; }
    public DateTime JoinDate { get; set; }

    public override decimal CalculateSalary()
    {
        int yearsOfExperience = DateTime.Now.Year - JoinDate.Year;
        decimal bonus = yearsOfExperience * 500; // bonus calculation 
        return base.CalculateSalary() + bonus;
    }
}