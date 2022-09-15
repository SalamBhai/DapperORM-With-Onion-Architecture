using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IApplicationDbContext _dbContext;
        private readonly IApplicationReadDbConnection _readDbConnection;
        private readonly IApplicationWriteDbConnection _writeDbConnection;
        public EmployeeController(IApplicationDbContext dbContext, IApplicationReadDbConnection readDbConnection, IApplicationWriteDbConnection writeDbConnection)
        {
            _dbContext = dbContext;
            _readDbConnection = readDbConnection;
            _writeDbConnection = writeDbConnection;
        }

      

        [HttpGet("GetAllEmployees")] 
        public async Task<IActionResult> GetAllEmployees()
        {
            var query = $"SELECT * FROM Employees";
            var employees = await _readDbConnection.QueryAsync<Employee>(query);
            return Ok(employees);
        }
    }
}
