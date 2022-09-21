using System.Data;
using System.Linq.Expressions;
using Application.DTOs.RequestModels;
using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IDepartmentRepository 
{
    Task<Department> CreateDepartmentAsyncWithDapper(CreateDepartmentRequestModel model, IDbTransaction transaction);
     Task<Department> UpdateDepartmentAsync(Department department);
    Task<IEnumerable<Department>> GetDepartmentsAsyncWithDapper();
    Task<Department> GetDepartmentAsyncEfCore(int Id);
    Task<Department> GetDepartmentAsyncEfCore(Expression<Func<Department, bool>> expression);
    Task<Department> GetDepartmentAsyncWithDapper(string Name);
}
