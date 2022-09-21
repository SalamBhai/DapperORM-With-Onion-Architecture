using System.Data.Common;
using Application.DTOs.RequestModels;
using Application.Interfaces.Services;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IApplicationDbContext _dbContext;

        public EmployeeController(IEmployeeService employeeService, IApplicationDbContext dbContext)
        {
            _employeeService = employeeService;
            _dbContext = dbContext;
        }

        [HttpPost("CreateEmployeeAlongWithDepartment")]
        public async Task<IActionResult> CreateEmployeeAlongWithDepartment([FromBody] CreateEmployeeRequestModel requestModel)
        {
            // var response = await _employeeService.CreateEmployeeAlongWithDepartment(requestModel);
            // if(!response.IsSuccessful) return BadRequest(response);
            // return Ok(response);
            _dbContext.Connection.Open();
            using (var transaction = _dbContext.Connection.BeginTransaction())
            {
                try
                {
                    _dbContext.Database.UseTransaction(transaction as DbTransaction);
                    var response = await _employeeService.CreateEmployeeAlongWithDepartment(requestModel, transaction);
                    transaction.Commit();
                    if (!response.IsSuccessful) return BadRequest(response);
                    return Ok(response);
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    _dbContext.Connection.Close();
                }
            }
        }
        [HttpGet("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var response = await _employeeService.GetEmployeesAsyncWithDapper();
            if (!response.IsSuccessful) return BadRequest(response);
            return Ok(response);
        }
        [HttpPut("UpdateEmployeeAndDepartment")]
        public async Task<IActionResult> UpdateEmployeeAndDepartment([FromBody] UpdateEmployeeRequestModel requestModel)
        {
            _dbContext.Connection.Open();
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                      _dbContext.Database.UseTransaction(transaction as DbTransaction);
                    var response = await _employeeService.UpdateEmployeeAsync(requestModel);
                    transaction.Commit();
                    if (!response.IsSuccessful) return BadRequest(response);
                    return Ok(response);
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    _dbContext.Connection.Close();
                }
            }
        }

        [HttpGet("GetEmployeeAsyncWithDapper")]
        public async Task<IActionResult> GetEmployeeWithDapper([FromQuery] string Name)
        {
            var response = await _employeeService.GetEmployeeAsyncWithDapper(Name);
            if (!response.IsSuccessful) return BadRequest(response);
            return Ok(response);
        }

        [HttpGet("GetEmployeeAsyncWithEfCore")]
        public async Task<IActionResult> GetEmployeeWithDapper([FromQuery] int Id)
        {
            var response = await _employeeService.GetEmployeeAsyncEfCore(Id);
            if (!response.IsSuccessful) return BadRequest(response);
            return Ok(response);
        }
    }
}
