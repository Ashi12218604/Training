using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using DeliveryService.Application.Commands;
using DeliveryService.Application.Queries;

namespace DeliveryService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DeliveryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DeliveryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{trackingNumber}")]
        public async Task<IActionResult> GetTrackingStatus(string trackingNumber)
        {
            try
            {
                var result = await _mediator.Send(new GetDeliveryStatusQuery(trackingNumber));
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> ScheduleDelivery([FromBody] CreateDeliveryCommand command)
        {
            try
            {
                var trackingNumber = await _mediator.Send(command);
                return Ok(new { Message = "Delivery scheduled.", TrackingNumber = trackingNumber });
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}