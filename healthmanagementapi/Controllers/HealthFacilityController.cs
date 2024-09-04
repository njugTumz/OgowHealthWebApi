using healthmanagementapi.Dtos;
using healthmanagementapi.Entities;
using healthmanagementapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace healthmanagementapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthFacilityController : ControllerBase
    {
        private readonly IHealthFacilityService _service;

        public HealthFacilityController(IHealthFacilityService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_service.GetAllFacilitiesAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var facility = await _service.GetFacilityByIdAsync(id);
            if (facility == null)
                return NotFound();

            return Ok(facility);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]HealthFacilityDto facility)
        {
            var newFacility = new HealthFacility()
            {
                Name = facility.Name,
                Country = facility.Country,
                District = facility.District,
                Region = facility.Region
            };

            await _service.CreateFacilityAsync(newFacility);
            return CreatedAtAction(nameof(GetById), new { id = newFacility.Id }, newFacility);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] HealthFacility facility)
        {
            if (id != facility.Id)
                return BadRequest();

            await _service.UpdateFacilityAsync(facility);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteFacilityAsync(id);
            return NoContent();
        }
    }
}
