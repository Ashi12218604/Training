using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.Commands;
using ProductService.Application.Queries;

namespace ProductService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]   // Every endpoint in this controller requires a valid JWT by default
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // ─── GET /api/products ─────────────────────────────────────────────────
        // All authenticated users can browse the catalogue
        [HttpGet]
        public async Task<IActionResult> GetAllCoffees()
        {
            var result = await _mediator.Send(new GetCoffeeListQuery());
            return Ok(result);
        }

        // ─── GET /api/products/{id} ────────────────────────────────────────────
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            if (product is null)
                return NotFound(new { message = $"Product {id} not found." });

            return Ok(product);
        }

        // ─── POST /api/products ────────────────────────────────────────────────
        // Only Superadmin or Admin can add new products to the catalogue
        [HttpPost]
        [Authorize(Roles = "Superadmin,Admin")]
        public async Task<IActionResult> CreateCoffee([FromBody] CreateCoffeeCommand command)
        {
            var productId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = productId }, new { id = productId });
        }

        // ─── PUT /api/products/{id}/price ──────────────────────────────────────
        // Update carton price (Admin+)
        [HttpPut("{id:guid}/price")]
        [Authorize(Roles = "Superadmin,Admin")]
        public async Task<IActionResult> UpdatePrice(Guid id, [FromBody] UpdatePriceRequest request)
        {
            var success = await _mediator.Send(new UpdateCoffeePricingCommand(id, request.NewCartonPrice));
            if (!success)
                return NotFound(new { message = $"Product {id} not found." });

            return NoContent();
        }

        // ─── DELETE /api/products/{id} ─────────────────────────────────────────
        // Soft-delete (sets IsActive = false) — Superadmin only
        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Superadmin")]
        public async Task<IActionResult> Deactivate(Guid id)
        {
            var success = await _mediator.Send(new DeactivateProductCommand(id));
            if (!success)
                return NotFound(new { message = $"Product {id} not found." });

            return NoContent();
        }
    }

    // ─── Request DTO (keeps command clean) ────────────────────────────────────
    public record UpdatePriceRequest(decimal NewCartonPrice);
}
