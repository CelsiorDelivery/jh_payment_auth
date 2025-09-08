using jh_payment_auth.DTOs;
using jh_payment_auth.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace jh_payment_auth.Controllers
{
    /// <summary>
    /// Provides API endpoints for managing user-related operations, such as registration.
    /// </summary>
    /// <remarks>This controller handles user-related requests and delegates the operations to the underlying
    /// user service. It is designed to process HTTP requests for user management, including creating new
    /// users.</remarks>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService registrationService)
        {
            _userService = registrationService;
        }

        /// <summary>
        /// Registers a new user based on the provided registration details.
        /// </summary>
        /// <remarks>This method processes the user registration request by delegating the operation to
        /// the user service.  Ensure that the <paramref name="request"/> object contains all required fields and
        /// adheres to the expected format.</remarks>
        /// <param name="request">The user registration details, including required information such as username, password, and email.</param>
        /// <returns>An <see cref="IActionResult"/> containing the result of the registration operation.  Returns a 201 Created
        /// response with a success message if the registration is successful,  or a 500 Internal Server Error response
        /// with an error message if the registration fails.</returns>
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationRequest request)
        {
            var result = await _userService.RegisterUserAsync(request);

            if (result.Errors.Count > 0)
            {
                result.Message = "User registration failed.";
                return StatusCode(result.StatusCode, result);
            }
            else
            {
                result.StatusCode = StatusCodes.Status201Created;
                result.Message = "User registered successfully.";
                return Ok(result);
            }
        }
    }
}
