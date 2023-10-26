using HRM.API.Db;
using HRM.API.Models;
using HRM.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM.API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly HRMContext _context;

        public EmployeeController(IEmployeeRepository employeeRepository, HRMContext context)
        {
            _employeeRepository = employeeRepository;
            _context = context;
        }

        [HttpGet(Name = "GetAllEmployee")]
        public async Task<ActionResult<List<Employee>>> GetEmployee()
        {
            var employee = await this._employeeRepository.SelectAllEmployees();
            return Ok(employee);
        }

    }
}
