using healthmanagementapi.Dtos;
using healthmanagementapi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace healthmanagementapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManagamentService _userService;

        public UserController(IUserManagamentService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterModel model)
        {
            var result = await _userService.RegisterUserAsync(model.Email, model.Password,model.Name);

            if (result.Succeeded)
                return Ok("User registered successfully.");

            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginModel model)
        {
            var token = await _userService.LoginUserAsync(model.Email, model.Password);

            if (token != null)
                return Ok(new { Token = token });

            return Unauthorized("Invalid login attempt.");
        }

        [HttpPost("change-password")]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel model)
        {
            var result = await _userService.ChangePasswordAsync(model.Email, model.CurrentPassword, model.NewPassword);

            if (result.Succeeded)
                return Ok("Password changed successfully.");

            return BadRequest(result.Errors);
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model)
        {
            var result = await _userService.ResetPasswordAsync(model.Email, model.Token, model.NewPassword);

            if (result.Succeeded)
                return Ok("Password reset successfully.");

            return BadRequest(result.Errors);
        }
    }
}
