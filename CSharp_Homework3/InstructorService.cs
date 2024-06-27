namespace Assignment3;

public class InstructorService : PersonService, IInstructorService
{
    public void AssignToDepartment(Instructor instructor, Department department)
    {
        instructor.Department = department;
        if (department.Head == null)
        {
            department.Head = instructor;
        }
    }

    public void DisplayInstructorInfo(Instructor instructor)
    {
        Console.WriteLine($"Instructor: {instructor.Name}, Department: {instructor.Department?.DepartmentName}, Salary: {instructor.CalculateSalary()}");
    }
}