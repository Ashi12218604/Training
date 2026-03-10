using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SimpleWebAPI.Models;


namespace SimpleWebAPI.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class StudentController : ControllerBase
        {
            [HttpGet]   
            public IActionResult GetStudents()

        {
            var students = new List<Student>
            {
                new Student { Id = 1, Name = "Alice", Marks = 80 },
                new Student { Id = 2, Name = "Bob", Marks = 60 },
                new Student { Id = 3, Name = "Charlie", Marks = 90 }
            };
            return Ok(students);
        }
    }
}
