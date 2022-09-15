using Domain.Contract;
namespace Domain.Entities;

public class Employee : AuditableEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
}
