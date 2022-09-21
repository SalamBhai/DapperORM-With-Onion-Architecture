namespace Application.DTOs.RequestModels;

public class UpdateEmployeeRequestModel
{
    public int Id {get; set;}
    public string Name {get; set;}
    public string Email {get; set;}
    public UpdateDepartmentRequestModel departmentRequestModel {get; set;}
}
