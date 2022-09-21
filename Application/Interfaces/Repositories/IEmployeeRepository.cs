using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IEmployeeRepository 
{
    Task<Employee> CreateEmployeeAsyncWithEfCore(Employee employee);
     Task<Employee> UpdateEmployeeAsync(Employee employee);
    Task<IEnumerable<Employee>> GetEmployeesAsyncWithDapper();
    Task<Employee> GetEmployeeAsyncEfCore(int Id);
    Task<Employee> GetEmployeeAsyncWithDapper(string Email);
    
}
