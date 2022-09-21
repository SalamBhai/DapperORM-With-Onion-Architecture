using Application.DTOs.RequestModels;
using Application.DTOs.ResponseModels;

namespace Application.Interfaces.Services;

public interface IDepartmentService
{
    // Task<BaseResponse> CreateDepartmentAsyncWithDapper(CreateDepartmentRequestModel model);
     //Task<BaseResponse<DepartmentDto>> UpdateDepartmentAsync(UpdateDepartmentRequestModel model);
    Task<BaseResponse<IEnumerable<DepartmentDto>>>   GetDepartmentsAsyncWithDapper();
    Task<BaseResponse<DepartmentDto>> GetDepartmentAsyncEfCore(int Id);
    Task<BaseResponse<DepartmentDto>> GetDepartmentAsyncWithDapper(string Name);
}
