using Add1To100.Model;
using Microsoft.AspNetCore.Mvc;

namespace Add1To100.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddController : ControllerBase
    {
        [HttpPost("sum")]
        public IActionResult AddNumbers([FromBody] NumberRequest request)
        {
            if (request.Number < 1 || request.Number > 100)
            {
                return BadRequest("Number must be between 1 and 100");
            }

            int sum = 0;

            for (int i = 1; i <= request.Number; i++)
            {
                sum += i;
            }

            return Ok(new
            {
                Input = request.Number,
                Result = sum
            });
        }
    }
}