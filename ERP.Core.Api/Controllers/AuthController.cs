using ERP.Core.Api.Contracts.Auth;
using ERP.Core.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Core.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var result = _authService.Login(request);
            return Ok(result);
        }
    }
}
