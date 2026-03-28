using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System;
using System.Threading.Tasks;
using InventoryService.Application.Commands;
using InventoryService.Application.Queries;

namespace InventoryService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Requires JWT token!
    public class InventoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InventoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetStock(Guid productId)
        {
            var result = await _mediator.Send(new GetStockQuery(productId));
            return Ok(result);
        }

        [HttpPost("adjust")]
        public async Task<IActionResult> AdjustStock([FromBody] AdjustStockCommand command)
        {
            try
            {
                var success = await _mediator.Send(command);
                return Ok(new { Message = "Stock adjusted successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}