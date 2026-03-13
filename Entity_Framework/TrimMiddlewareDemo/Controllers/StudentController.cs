using Microsoft.AspNetCore.Mvc;

namespace TrimMiddlewareDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        [HttpPost]
        public IActionResult ReverseName([FromBody] Student student)
        {
            if (student == null || string.IsNullOrEmpty(student.name))
                return BadRequest("Name is required");

            // Reverse the name
            char[] arr = student.name.ToCharArray();
            Array.Reverse(arr);
            string reversedName = new string(arr);

            return Ok(new
            {
                originalName = student.name,
                reversedName = reversedName,
     
            });
        }
    }
}
   