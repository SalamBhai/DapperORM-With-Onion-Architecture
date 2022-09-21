namespace Application.DTOs.RequestModels;

public class CreateDepartmentRequestModel
{
    public string Name {get; set;}
    public string Description {get; set;}
    public DateTime CreatedOn {get; set;} = DateTime.UtcNow;
}
