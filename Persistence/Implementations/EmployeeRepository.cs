using Application.Interfaces.Repositories;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Implementations;

public class EmployeeRepository : IEmployeeRepository
{
     private IApplicationDbContext _dbContext;
    private IApplicationWriteDbConnection _writeConnection;
    private IApplicationReadDbConnection _readConnection;

    public EmployeeRepository(IApplicationDbContext dbContext, IApplicationWriteDbConnection writeConnection, IApplicationReadDbConnection readConnection)
    {
        _dbContext = dbContext;
        _writeConnection = writeConnection;
        _readConnection = readConnection;
    }

    public async Task<Employee> CreateEmployeeAsyncWithEfCore(Employee employee)
    {
        await _dbContext.Employees.AddAsync(employee);
        await _dbContext.SaveChangesAsync(default);
        return employee;
    }

    public async Task<Employee> GetEmployeeAsyncEfCore(int Id)
    {
        var employee = await _dbContext.Employees.Include(emp => emp.Department).SingleOrDefaultAsync(emp => emp.Id == Id);
        return employee;
    }

    public async Task<Employee> GetEmployeeAsyncWithDapper(string Email)
    {
       var query = $"SELECT * FROM EMPLOYEES E WHERE E.Email = {Email} inner join DEPARTMENTS D on E.DepartmentId = D.Id";
       var employee =  await _readConnection.QuerySingleAsync<Employee>(query);
       return employee;
    }

    public async Task<IEnumerable<Employee>> GetEmployeesAsyncWithDapper()
    {
        var employees = await _readConnection.QueryAsync<Employee>("SELECT * FROM EMPLOYEES");
        return employees;
    }

    public async Task<Employee> UpdateEmployeeAsync(Employee employee)
    {
        _dbContext.Employees.Update(employee);
        await _dbContext.SaveChangesAsync(default);
        return employee;
    }
}
