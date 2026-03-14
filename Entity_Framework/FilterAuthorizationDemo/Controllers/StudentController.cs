using Microsoft.AspNetCore.Mvc;
using FilterAuthorizationDemo.Attributes;

namespace FilterAuthorizationDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(new List<string> { "Ashi", "Sanjana", "Aryan" });
        }

        [AdminAuthorize]
        [HttpDelete("{name}")]
        public IActionResult DeleteStudent(string name)
        {
            return Ok($"{name} deleted successfully");
        }
    }
}