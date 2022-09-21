using System.Data;
using System.Data.Common;
using Application.DTOs.RequestModels;
using Application.DTOs.ResponseModels;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Implementations.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IDepartmentRepository _deptRepository;
    private readonly IApplicationDbContext _dbContext;

    public EmployeeService(IEmployeeRepository employeeRepository, IDepartmentRepository deptRepository, IApplicationDbContext dbContext)
    {
        _employeeRepository = employeeRepository;
        _deptRepository = deptRepository;
        _dbContext = dbContext;
    }

    public async Task<BaseResponse> CreateEmployeeAlongWithDepartment(CreateEmployeeRequestModel model, IDbTransaction transaction)
    {

        //  _dbContext.Database.UseTransaction(transaction as DbTransaction);
        var department = await _deptRepository.GetDepartmentAsyncEfCore(dept => dept.Name == model.departmentRequestModel.Name);
        if (department is not null)
        {
            throw new Exception("Department Already Exists");
        }
        var departmentCreated = await _deptRepository.CreateDepartmentAsyncWithDapper(model.departmentRequestModel, transaction: transaction);
        if (departmentCreated is null)
        {
            throw new Exception("Transaction Failed");
        }

        var employee = new Employee
        {
            Name = model.Name,
            Email = model.Email,
            DepartmentId = departmentCreated.Id,
            CreatedOn = DateTime.UtcNow,
            CreatedBy = 1,
        };
        await _employeeRepository.CreateEmployeeAsyncWithEfCore(employee);
        return new BaseResponse
        {
            IsSuccessful = true,
            Message = "Employee And Department Successfully Created Cheers!"
        };



    }

    public async Task<BaseResponse<EmployeeDTO>> GetEmployeeAsyncEfCore(int Id)
    {
        var employee = await _employeeRepository.GetEmployeeAsyncEfCore(Id);
        if (employee is null)
        {
            return new BaseResponse<EmployeeDTO>
            {
                IsSuccessful = false,
                Message = " Retrieval Of Employee Failed"
            };
        }
        var employeeDto = new EmployeeDTO
        {
            Id = employee.Id,
            Email = employee.Email,
            Name = employee.Name,
            departmentDto = new DepartmentDto
            {
                Description = employee.Department.Description,
                Id = employee.DepartmentId,
                Name = employee.Department.Name
            }
        };
        return new BaseResponse<EmployeeDTO>
        {
            Data = employeeDto,
            IsSuccessful = true,
            Message = "Retrieval Successful Of Employee Info"
        };
    }

    public async Task<BaseResponse<EmployeeDTO>> GetEmployeeAsyncWithDapper(string Email)
    {
        var employee = await _employeeRepository.GetEmployeeAsyncWithDapper(Email);
        if (employee is null)
        {
            return new BaseResponse<EmployeeDTO>
            {
                IsSuccessful = false,
                Message = " Retrieval Of Employee Failed"
            };
        }
        var employeeDto = new EmployeeDTO
        {
            Id = employee.Id,
            Email = employee.Email,
            Name = employee.Name,
            departmentDto = new DepartmentDto
            {
                Description = employee.Department.Description,
                Id = employee.DepartmentId,
                Name = employee.Department.Name
            }
        };
        return new BaseResponse<EmployeeDTO>
        {
            Data = employeeDto,
            IsSuccessful = true,
            Message = "Retrieval Successful Of Employee Info"
        };
    }


    public async Task<BaseResponse<IEnumerable<EmployeeDTO>>> GetEmployeesAsyncWithDapper()
    {
        var employees = await _employeeRepository.GetEmployeesAsyncWithDapper();
        if (employees is null) return new BaseResponse<IEnumerable<EmployeeDTO>>
        {
            IsSuccessful = false,
            Message = "Successful Employees Retrieval",
        };
        var employeesDto = employees.Select(emp => new EmployeeDTO
        {
            Email = emp.Email,
            Id = emp.Id,
            Name = emp.Name,
        }).ToList();

        return new BaseResponse<IEnumerable<EmployeeDTO>>
        {
            Data = employeesDto,
            IsSuccessful = true,
            Message = "Request Made Successfully",
        };
    }

    public async Task<BaseResponse<EmployeeDTO>> UpdateEmployeeAsync(UpdateEmployeeRequestModel model)
    {
        var dept = await _deptRepository.GetDepartmentAsyncEfCore(model.Id);

        var employee = await _employeeRepository.GetEmployeeAsyncEfCore(model.Id);
        if (employee is null)
        {
            return new BaseResponse<EmployeeDTO>
            {
                IsSuccessful = false,
                Message = "Update Of Employee Failed",
            };
        }
        employee.LastModifiedOn = DateTime.UtcNow;
        employee.Email = model.Email;
        employee.Name = model.Name;
        //_dbContext.Connection.Open();


        if (dept is null)
        {
            throw new Exception("Department Is Null, Update Failed");
        }
        dept.Name = model.departmentRequestModel.DepartmentName;
        dept.Description = model.departmentRequestModel.Description;
        dept.LastModifiedOn = DateTime.UtcNow;
        var updatedDept = await _deptRepository.UpdateDepartmentAsync(dept);
        if (updatedDept is null)
        {
            throw new Exception("Department Update Failed");
        }
        var updatedEmployee = await _employeeRepository.UpdateEmployeeAsync(employee);
        //transaction.Commit();
        return new BaseResponse<EmployeeDTO>
        {
            IsSuccessful = true,
            Message = "Successful Update"
        };








    }
}
