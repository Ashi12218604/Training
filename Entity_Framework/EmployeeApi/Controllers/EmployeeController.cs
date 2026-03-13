using Microsoft.AspNetCore.Mvc;
using EmployeeApi.Models;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>();
        [HttpPost("add")]
        public IActionResult AddEmployees([FromBody] List<Employee> empList)
        {
            employees.AddRange(empList);

            return Ok("Employees Added Successfully");
        }
        [HttpGet("all")]
        public IActionResult GetEmployees()
        {
            return Ok(employees);
        }
        [HttpGet("totalsalary")]
        public IActionResult GetTotalSalary()
        {
            double total = employees.Sum(e => e.Salary);

            return Ok(new { TotalSalary = total });
        }
    }
}