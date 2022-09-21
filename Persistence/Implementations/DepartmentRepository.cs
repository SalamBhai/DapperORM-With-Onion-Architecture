using System.Data;
using System.Data.Common;
using System.Linq.Expressions;
using Application.DTOs.RequestModels;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Implementations;

public class DepartmentRepository : IDepartmentRepository
{
    private IApplicationDbContext _dbContext;
    private IApplicationWriteDbConnection _writeConnection;
    private IApplicationReadDbConnection _readConnection;

    public DepartmentRepository(IApplicationDbContext dbContext, IApplicationWriteDbConnection writeConnection, IApplicationReadDbConnection readConnection)
    {
        _dbContext = dbContext;
        _writeConnection = writeConnection;
        _readConnection = readConnection;
    }

    public async Task<Department> CreateDepartmentAsyncWithDapper(CreateDepartmentRequestModel model, IDbTransaction transaction)
    {
         
        //var addDepartmentCommand = $"INSERT INTO Departments(Name,Description,CreatedBy,IsDeleted) VALUES('{model.Name}','{model.Description}','{1}','{false}');SELECT * From Departments WHERE Id = CAST(SCOPE_IDENTITY() as int)";
        var addDepartmentCommand = $"INSERT INTO Departments(Name,Description,CreatedBy,IsDeleted) VALUES('{model.Name}','{model.Description}','{1}','{false}');SELECT CAST(SCOPE_IDENTITY() as int)";
        var departmentId = await _writeConnection.QuerySingleAsync<int>(addDepartmentCommand, transaction: transaction);
        var department =  await _readConnection.QueryFirstOrDefaultAsync<Department>($"SELECT * FROM DEPARTMENTS WHERE Id = {departmentId};");
          return department;
    }

    public async Task<Department> GetDepartmentAsyncEfCore(int Id)
    {
       var department = await _dbContext.Departments.Where(dept => dept.Id == Id).SingleOrDefaultAsync();
       return department;
    }

    public async Task<Department> GetDepartmentAsyncEfCore(Expression<Func<Department, bool>> expression)
    {
        return await _dbContext.Departments.SingleOrDefaultAsync(expression);

    }

    public async Task<Department> GetDepartmentAsyncWithDapper(string Name)
    {
       var department = await _readConnection.QuerySingleAsync<Department>($"SELECT * FROM DEPARTMENTS WHERE Name = {Name}");
        return department;
    }

    public async Task<IEnumerable<Department>> GetDepartmentsAsyncWithDapper()
    {
        var departments = await _readConnection.QueryAsync<Department>("SELECT * FROM DEPARTMENTS");
        return departments;
    }

    public async Task<Department> UpdateDepartmentAsync(Department department)
    {
       _dbContext.Departments.Update(department);
       await _dbContext.SaveChangesAsync(default);
       return department;
    }
}
