using System.Data;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var Department1 = new Department
        {
            Id = 1,
            Name = "Legal Department",
            CreatedBy = 1,
            CreatedOn = DateTime.UtcNow,
            Description = "For Legal Activities",
            IsDeleted = false,
        };
        var Department2 = new Department
        {
            CreatedBy = 1,
            CreatedOn = DateTime.UtcNow,
            Name = "Toilet Department",
            Id = 2,
            Description = "For Sanitation",
            IsDeleted = false,
        };
        var employee1 = new Employee
        {
            CreatedBy = 1,
            CreatedOn = DateTime.UtcNow,
            Email = "Employee1@gmail.com",
            IsDeleted = false,
            Name = "Ganiyu Ganiyu",
            Id = 1,
            DepartmentId = Department1.Id,
        };
        var employee2 = new Employee
        {
            Id = 2,
            Email = "Employee2@gmail.com",
            IsDeleted = false,
            Name = "Abass Adebayo ",
            CreatedOn = DateTime.UtcNow,
            CreatedBy = 1,
            DepartmentId = Department2.Id,
        };
        modelBuilder.Entity<Department>().HasData(Department1, Department2);
        modelBuilder.Entity<Employee>().HasData(employee1, employee2);
    }

    public IDbConnection Connection => Database.GetDbConnection();

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
}
