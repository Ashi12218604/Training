using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderService.Application.Commands;
using OrderService.Application.Queries;
using System;
using System.Threading.Tasks;

namespace OrderService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            try
            {
                // MediatR takes the incoming JSON and routes it directly to your Handler!
                var orderId = await _mediator.Send(command);

                return Ok(new
                {
                    Message = "Order placed successfully!",
                    OrderId = orderId
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("my-orders")]
        public async Task<IActionResult> GetMyOrders()
        {
            try
            {
                // Extract the UserId directly from the JWT Token claims
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value
                                  ?? User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(userIdClaim))
                    return Unauthorized(new { message = "Invalid token or missing User ID." });

                var query = new GetMyOrdersQuery(Guid.Parse(userIdClaim));
                var orders = await _mediator.Send(query);

                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}