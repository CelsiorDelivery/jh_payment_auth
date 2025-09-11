using jh_payment_auth.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace jh_payment_auth.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/auth/[Controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IAuthService _authService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authService"></param>
        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("signin")]
        public IActionResult Login([FromBody] Models.LoginRequest request)
        {
            var result = _authService.Login(request);
            if (result == null) return Unauthorized("Invalid username or password");
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("secure-data")]
        [Authorize]
        public IActionResult GetSecureData()
        {
            var username = User.Identity?.Name;
            return Ok(new { Message = $"Hello {username}, you are authenticated!" });
        }
    }
}
