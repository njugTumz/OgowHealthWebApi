using healthmanagementapi.Dtos;
using healthmanagementapi.Entities;
using healthmanagementapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace healthmanagementapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _service;

        public RoleController(IRoleService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _service.GetAllRolesAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var role = await _service.GetRoleByIdAsync(id);
            if (role == null)
                return NotFound();

            return Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Role role)
        {
            await _service.CreateRoleAsync(role);
            return CreatedAtAction(nameof(GetById), new { id = role.Id }, role);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Role role)
        {
            var result = await _service.UpdateRoleAsync(role);
            if (result.Succeeded)
                return Ok("Role updated successfully.");

            return BadRequest(result.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteRoleAsync(id);
            if (result.Succeeded)
                return Ok("Role deleted successfully.");

            return BadRequest(result.Errors);
        }

        [HttpPost("assign-role")]
        public async Task<IActionResult> AssignRoleToUser([FromBody] AssignRoleModel model)
        {
            var result = await _service.AssignRoleToUserAsync(model.UserId, model.RoleId);
            if (result.Succeeded)
                return Ok("Role assigned to user successfully.");

            return BadRequest(result.Errors);
        }
    }
}
