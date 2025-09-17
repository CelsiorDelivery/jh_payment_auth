using jh_payment_auth.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace jh_payment_auth.Controllers
{
    /// <summary>
    /// This controller handles authentication-related operations such as user login and accessing secure data.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/auth-service/[Controller]")]
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
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] Models.LoginRequest request)
        {
            var result = await _authService.Login(request);
            if (result == null || result.StatusCode != System.Net.HttpStatusCode.OK) 
                return Unauthorized("Invalid username or password");

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

        [HttpGet("admin-only")]
        [Authorize(Policy = "AdminOnly")] // Requires a valid JWT token with the "Admin" role claim.
        public IActionResult AdminOnlyEndpoint()
        {
            return Ok("This is a protected resource for Admins only.");
        }

        [HttpGet("merchant-only")]
        [Authorize(Policy = "MerchantOnly")] // Requires a valid JWT token with the "Merchant" role claim.
        public IActionResult MerchantOnlyEndpoint()
        {
            return Ok("This is a protected resource for Merchants only.");
        }
    }
}
