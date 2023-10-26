using HRM.API.Db;
using HRM.API.Models;
using HRM.API.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRM.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        //private readonly HRMContext _context;
        //private readonly IEmployeeRepository _employeeRepository;


        public WeatherForecastController(ILogger<WeatherForecastController> logger, HRMContext context)
        {
            _logger = logger;
            //_context = context;
            //_employeeRepository = employeeRepository;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        //[HttpGet(Name = "GetEmployee")]
        //[HttpGet(Name = "GetAllEmployee")]
        //public async Task<ActionResult<List<Employee>>> GetEmployee()
        //{
        //    var employee = await this._employeeRepository.SelectAllEmployees();
        //    return Ok(employee);
        //}

        //[HttpGet("GetAllCategories")]
        //public async Task<ActionResult<List<GetCategoryDetailsDto>>> GetAllCategories()
        //{
        //    var categories = await this._categoryRepository.GetAllAsync();
        //    var records = _mapper.Map<List<GetCategoryDetailsDto>>(categories);
        //    return Ok(records);
        //}

    }
}
