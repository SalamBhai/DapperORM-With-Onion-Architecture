using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentService _departmentService;

    public DepartmentController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpGet("GetDepartmentAsyncWithDapper")]
    public async Task<IActionResult> GetDepartmentAsyncWithDapper([FromQuery] string Name)
    {
        var response = await _departmentService.GetDepartmentAsyncWithDapper(Name);
        if (!response.IsSuccessful) return BadRequest(response);
        return Ok(response);
    }

     [HttpGet("GetDepartmentAsyncWithEfCore")]
    public async Task<IActionResult> GetDepartmentAsyncWithEfCore([FromQuery] int Id)
    {
        var response = await _departmentService.GetDepartmentAsyncEfCore(Id);
        if (!response.IsSuccessful) return BadRequest(response);
        return Ok(response);
    }

      [HttpGet("GetDepartmentsAsyncWithDapper")]
    public async Task<IActionResult> GetDepartmentsAsyncWithDapper()
    {
        var response = await _departmentService.GetDepartmentsAsyncWithDapper();
        if (!response.IsSuccessful) return BadRequest(response);
        return Ok(response);
    }
}
