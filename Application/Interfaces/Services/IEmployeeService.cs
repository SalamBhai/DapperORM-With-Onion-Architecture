using System.Data;
using Application.DTOs.RequestModels;
using Application.DTOs.ResponseModels;

namespace Application.Interfaces.Services;

public interface IEmployeeService
{
     Task<BaseResponse> CreateEmployeeAlongWithDepartment(CreateEmployeeRequestModel model, IDbTransaction transaction);
     Task<BaseResponse<EmployeeDTO>> UpdateEmployeeAsync(UpdateEmployeeRequestModel model);
    Task<BaseResponse<IEnumerable<EmployeeDTO>>> GetEmployeesAsyncWithDapper();
    Task<BaseResponse<EmployeeDTO>> GetEmployeeAsyncEfCore(int Id);
    Task<BaseResponse<EmployeeDTO>> GetEmployeeAsyncWithDapper(string Name);
}
