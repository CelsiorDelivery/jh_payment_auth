using jh_payment_auth.Models;
using jh_payment_auth.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace jh_payment_auth.Controllers
{
    /// <summary>
    /// This controller handles authentication-related operations such as user login and accessing secure data.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// This endpoint allows users to log in by providing their username and password.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public IActionResult Login([FromBody] Models.LoginRequest request)
        {
            var result = _authService.Login(request);
            if (result == null) return Unauthorized("Invalid username or password");
            return Ok(result);
        }

        /// <summary>
        /// This endpoint returns secure data and requires the user to be authenticated.
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
