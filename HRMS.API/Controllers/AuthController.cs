using HRMS.Application.DTOs;
using HRMS.Application.Interface;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto data)
        {
            var result = await _authService.LoginAsync(data);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
