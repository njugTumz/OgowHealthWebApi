using healthmanagementapi.Dtos;
using healthmanagementapi.Entities;
using healthmanagementapi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace healthmanagementapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _service;

        public PatientsController(IPatientService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllPatientsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var patient = await _service.GetPatientByIdAsync(id);
            if (patient == null)
                return NotFound();

            return Ok(patient);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PatientDto patient)
        {
            var newPatient = new Patient()
            {
                 Address = patient.Address,
                 Gender = patient.Gender,
                 HealthFacilityID = patient.HealthFacilityID,
                 Name = patient.Name,
            };

            await _service.CreatePatientAsync(newPatient);
            return CreatedAtAction(nameof(GetById), new { id = newPatient.Id }, newPatient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PatientDto patient)
        {
            if (id != patient.Id)
                return BadRequest();

            var newPatient = new Patient()
            {
                Id = (int)patient?.Id,
                Address = patient.Address,
                Gender = patient.Gender,
                HealthFacilityID = patient.HealthFacilityID,
                Name = patient.Name,
            };

            await _service.UpdatePatientAsync(newPatient);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeletePatientAsync(id);
            return NoContent();
        }
    }
}
