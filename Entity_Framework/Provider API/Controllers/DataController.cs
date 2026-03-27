using Microsoft.AspNetCore.Mvc;

namespace Provider_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetData()
        {
            var data = new
            {
                Id = 1,
                Name = "Ashi",
                Role = "Data Scientist"
            };

            return Ok(data);
        }
    }
}