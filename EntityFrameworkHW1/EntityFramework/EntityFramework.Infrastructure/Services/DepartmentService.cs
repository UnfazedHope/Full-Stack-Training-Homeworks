using EntityFramework.Core.Entities;
using EntityFramework.Core.Interfaces.Services;
using EntityFramework.Core.Models.RequestModel;
using EntityFramework.Core.Models.ResponseModel;
using EntityFramework.Infrastructure.Repositories;
using Serilog;

namespace EntityFramework.Infrastructure.Services;

public class DepartmentService : IDepartmentService
{
    private DepartmentRepository _departmentRepository = new DepartmentRepository();


    public List<DepartmentResponseModel> GetAllDepartments()
    {
        var departments = _departmentRepository.GetAll();
        var departmentResponseModels = new List<DepartmentResponseModel>();
        foreach (var department in departments)
        {
            departmentResponseModels.Add(new DepartmentResponseModel
            {
                DepartmentName = department.DepartmentName,
                Location = department.Location
            });
        }
        Log.Information("GetAll departments method has been called");
        return departmentResponseModels;
    }

    public DepartmentResponseModel GetById(int id)
    {
        var department = _departmentRepository.GetById(id);
        if (department != null)
        {
            var departmentResponseModel = new DepartmentResponseModel
            {
                DepartmentName = department.DepartmentName,
                Location = department.Location
            };
            return departmentResponseModel;
        }

        return null;
    }

    public int AddDepartment(DepartmentRequestModel model)
    {
        var departmentEntity = new Department
        {
            DepartmentName = model.DepartmentName,
            Location = model.Location
        };
        Log.Information("Department has been added");
        return _departmentRepository.Insert(departmentEntity);
    }
}