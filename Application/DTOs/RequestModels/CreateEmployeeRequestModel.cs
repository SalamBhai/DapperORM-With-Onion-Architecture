using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.RequestModels;

public class CreateEmployeeRequestModel
{
    [Required]
    public string Name {get; set;}
    [Required]
    [EmailAddress]
    public string Email {get; set;}
    public CreateDepartmentRequestModel departmentRequestModel {get; set;}


}
