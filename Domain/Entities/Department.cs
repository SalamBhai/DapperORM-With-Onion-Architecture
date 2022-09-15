using Domain.Contract;
namespace Domain.Entities;

public class Department : AuditableEntity
{
    public string Name { get; set; }
     public string Description { get; set; }
}
