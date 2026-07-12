using Microsoft.AspNetCore.Mvc;
using POSSystemWebAPI.Interfaces;
using POSSystemWebAPI.Models.DTOs;

namespace POSSystemWebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _service;
        public OrderItemController(IOrderItemService service) => _service = service;

        // GET api/orderitem
        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllAsync());

        // POST api/orderitem
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] List<OrderItemDto> dtos)
        {
            if (dtos is null || dtos.Count == 0)
                return BadRequest("No items provided.");

            var userName = User?.Identity?.Name ?? "system";   // from JWT once auth is added
            await _service.SaveAsync(dtos, userName);
            return Ok(new { message = "Items saved.", count = dtos.Count });
        }
    }
}