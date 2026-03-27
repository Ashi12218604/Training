using Microsoft.AspNetCore.Mvc;

namespace Consumer_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CallController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public CallController(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient();
        }

        [HttpGet]
        public async Task<IActionResult> CallProviderAPI()
        {
            string url = "https://pauline-phantomlike-paula.ngrok-free.dev/api/data"; // Provider API URL

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode);

            var data = await response.Content.ReadAsStringAsync();

            return Ok(data);
        }
    }
}