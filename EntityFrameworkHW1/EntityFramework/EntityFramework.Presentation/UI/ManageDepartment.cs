using EntityFramework.Core.Entities;
using EntityFramework.Core.Models.RequestModel;
using EntityFramework.Infrastructure.Repositories;
using EntityFramework.Infrastructure.Services;

namespace EntityFramework.Presentation.UI;

public class ManageDepartment
{
    private DepartmentService _departmentService = new DepartmentService();
    
    private void AddDepartment()
    {
        DepartmentRequestModel departmentRequestModel = new DepartmentRequestModel();
        Console.WriteLine("Please enter department name");
        departmentRequestModel.DepartmentName = Console.ReadLine();
        Console.WriteLine("Please enter department location");
        departmentRequestModel.Location = Console.ReadLine();
        Console.WriteLine(_departmentService.AddDepartment(departmentRequestModel));
    }

    private void PrintAllDepartments()
    {
        var departments = _departmentService.GetAllDepartments();
        foreach (var department in departments)
        {
            Console.WriteLine(department.DepartmentName + "\t" + department.Location);
        }
    }

    private void GetDepartmentById()
    {
        Console.WriteLine("Please enter department Id");
        int id = Convert.ToInt32(Console.ReadLine());
        var department = _departmentService.GetById(id);
        Console.WriteLine(department.DepartmentName + "\t" + department.Location);
    }

    public void Run()
    {
        GetDepartmentById();
    }
}