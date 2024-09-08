using healthmanagementapi.Dtos;
using healthmanagementapi.Entities;
using healthmanagementapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace healthmanagementapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthWorkerController : ControllerBase
    {
        private readonly IHealthWorkerService _service;

        public HealthWorkerController(IHealthWorkerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok( await _service.GetAllHealthWorkersAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var hw = await _service.GetHealthWorkerByIdAsync(id);
            if (hw == null)
                return NotFound();

            return Ok(hw);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] HealthWorkerDto hw)
        {
            var newHw = new HealthWorker()
            {
                 Designation = hw.Designation,
                 Email = hw.Email,
                 Name = hw.Name,
                 PhoneNumber = hw.PhoneNumber,
                 HealthFacilityID = hw.HealthFacilityID
            };

            await _service.CreateHealthWorkerAsync(newHw);
            return CreatedAtAction(nameof(GetById), new { id = newHw.Id }, newHw);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] HealthWorkerDto hw)
        {
            if (id != hw.Id)
                return BadRequest();

            var newHw = new HealthWorker()
            {
                Id = (int)hw?.Id,
                Designation = hw.Designation,
                Email = hw.Email,
                Name = hw.Name,
                PhoneNumber = hw.PhoneNumber,
                HealthFacilityID = hw.HealthFacilityID
            };

            await _service.UpdateHealthWorkerAsync(newHw);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteHealthWorkerAsync(id);
            return NoContent();
        }
    }
}
