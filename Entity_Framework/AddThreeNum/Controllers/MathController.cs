using AddThreeNum.Models;
using Microsoft.AspNetCore.Mvc;

namespace AddThreeNum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MathController : ControllerBase
    {
        [HttpPost("add")]
        public IActionResult AddNumbers([FromBody] Numbers nums)
        {
            int sum = nums.Num1 + nums.Num2 + nums.Num3;

            return Ok(new
            {
                result = sum
            });
        }
    }
}