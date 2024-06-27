namespace Assignment3;

public class Department
{
    public string DepartmentName { get; set; }
    public Instructor Head { get; set; }
    public DateTime BudgetStart { get; set; }
    public DateTime BudgetEnd { get; set; }
    public decimal Budget { get; set; }
    public List<Course> Courses { get; } = new List<Course>();
}