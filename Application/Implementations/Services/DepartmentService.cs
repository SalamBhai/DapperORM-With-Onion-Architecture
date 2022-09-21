using Application.DTOs.RequestModels;
using Application.DTOs.ResponseModels;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;

namespace Application.Implementations.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentService(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    // public Task<BaseResponse> CreateDepartmentAsyncWithDapper(CreateDepartmentRequestModel model)
    // {
    //     throw new NotImplementedException();
    // }

    public async Task<BaseResponse<DepartmentDto>> GetDepartmentAsyncEfCore(int Id)
    {
        var dept = await _departmentRepository.GetDepartmentAsyncEfCore(Id);
        if (dept == null)
        {
            return new BaseResponse<DepartmentDto>
            {
                IsSuccessful = false,
                Message = "Failed To Retrieve Department"
            };
        }
        return new BaseResponse<DepartmentDto>
        {
            IsSuccessful = true,
            Message = "Successful Department Retrieval",
            Data = new DepartmentDto
            {
                Id = dept.Id,
                Description = dept.Description,
                Name = dept.Name,
            }
        };
    }

    public async Task<BaseResponse<DepartmentDto>> GetDepartmentAsyncWithDapper(string Name)
    {
        var dept = await _departmentRepository.GetDepartmentAsyncWithDapper(Name);
        if (dept.Equals(null))
        {
            return new BaseResponse<DepartmentDto>
            {
                IsSuccessful = false,
                Message = "Failed To Retrieve Department"
            };
        }
        return new BaseResponse<DepartmentDto>
        {
            IsSuccessful = true,
            Message = "Successful Retrieval",
            Data = new DepartmentDto
            {
                Id = dept.Id,
                Description = dept.Description,
                Name = dept.Name
            }
        };
    }

    public async Task<BaseResponse<IEnumerable<DepartmentDto>>> GetDepartmentsAsyncWithDapper()
    {
       var depts = await _departmentRepository.GetDepartmentsAsyncWithDapper();
       var departmentDTO =  depts.Select(dept => new DepartmentDto
       {
         Description = dept.Description,
         Id = dept.Id,
         Name = dept.Name,
       }).ToList();
       return new BaseResponse<IEnumerable<DepartmentDto>>
       {
          Data = departmentDTO,
          IsSuccessful = true,
          Message = "All Departments Retrieved",
       };
    }

    
}
