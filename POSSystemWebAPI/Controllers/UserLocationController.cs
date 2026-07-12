using Microsoft.AspNetCore.Mvc;
using POSSystemWebAPI.Interfaces;
using POSSystemWebAPI.Models.DTOs;

namespace POSSystemWebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserLocationController : ControllerBase
    {
        private readonly IUserLocationService _service;
        public UserLocationController(IUserLocationService service) => _service = service;

        // GET api/userlocation
        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllAsync());

        // POST api/userlocation
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] List<LocationDto> dtos)
        {
            if (dtos is null || dtos.Count == 0)
                return BadRequest("No locations provided.");

            await _service.SaveAsync(dtos);
            return Ok(new { message = "Locations saved.", count = dtos.Count });
        }
    }

}