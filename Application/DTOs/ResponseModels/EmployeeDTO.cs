namespace Application.DTOs.ResponseModels;

public class EmployeeDTO 
{
    public int Id {get; set;}
    public string Email {get; set;}
    public string Name {get; set;}
    public DepartmentDto departmentDto {get; set;}
}

