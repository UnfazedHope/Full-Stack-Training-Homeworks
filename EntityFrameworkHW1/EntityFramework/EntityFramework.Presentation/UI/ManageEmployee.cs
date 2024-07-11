using EntityFramework.Core.Models.RequestModel;
using EntityFramework.Infrastructure.Services;

namespace EntityFramework.Presentation.UI;

public class ManageEmployee
{
    private EmployeeService _employeeService = new EmployeeService();

    private void AddEmployee()
    {
        EmployeeRequestModel employeeRequestModel = new EmployeeRequestModel();
        Console.WriteLine("Please enter employee name");
        employeeRequestModel.EmployeeName = Console.ReadLine();
        Console.WriteLine("Please enter employee age");
        employeeRequestModel.Age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(_employeeService.AddEmployee(employeeRequestModel));
    }

    private void PrintAllEmployee()
    {
        var employees = _employeeService.GetAllEmployees();
        foreach (var employee in employees)
        {
            Console.WriteLine(employee.EmployeeName+ "\t" + employee.Age);
        }
    }

    private void GetEmployeeById()
    {
        Console.WriteLine("Please enter employee Id");
        int id = Convert.ToInt32(Console.ReadLine());
        var employee = _employeeService.GetById(id);
        Console.WriteLine(employee.EmployeeName+ "\t" + employee.Age);
    }
    
    // Added employee filter by age
    private void GetEmployeesByAge()
    {
        Console.WriteLine("Please enter the minimum age");
        int age = Convert.ToInt32(Console.ReadLine());
        var employees = _employeeService.GetAllEmployees();
        var filteredEmployees = employees.Where(e => e.Age >= age).ToList();
        foreach (var employee in filteredEmployees)
        {
            Console.WriteLine(employee.EmployeeName + "\t" + employee.Age);
        }
    }

    public void Run()
    {
        GetEmployeesByAge();
    }
}