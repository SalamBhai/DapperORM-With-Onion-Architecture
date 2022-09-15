
using System.Data;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Domain.Interfaces;

public interface IApplicationDbContext
{  public IDbConnection Connection { get; }
    DatabaseFacade Database { get; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
