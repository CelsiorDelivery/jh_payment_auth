using jh_payment_auth.Constants;
using jh_payment_auth.DTOs;
using jh_payment_auth.Helpers;
using jh_payment_auth.Services;
using jh_payment_auth.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens.Experimental;

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
        private readonly IValidationService _validationService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService registrationService,
            IValidationService validationService,
            ILogger<UsersController> logger)
        {
            _userService = registrationService;
            _validationService = validationService;
            _logger = logger;
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
        [HttpPost("Registration")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationRequest request)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                _logger.LogInformation("Received user registration request for email: {Email}", request.Email);
                // Step 1: Validate the incoming request data, including new fields.
                var validationErrors = _validationService.ValidateRegistrationRequest(request);
                if (validationErrors.Count > 0)
                {
                    _logger.LogError("User registration validation failed: {Errors}", string.Join(", ", validationErrors));
                    ErrorHandler.HandleErrors(ErrorMessages.UserValidationFailed, StatusCodes.Status400BadRequest, validationErrors, ref apiResponse);
                    return StatusCode(apiResponse.StatusCode, apiResponse);
                }

                apiResponse = await _userService.RegisterUserAsync(request);

                if (apiResponse.Errors != null && apiResponse.Errors.Count > 0)
                {
                    _logger.LogError("User registration failed: {Errors}", string.Join(", ", apiResponse.Errors));
                    apiResponse.Message = ErrorMessages.UserRegistrationFailed;
                    return StatusCode(apiResponse.StatusCode, apiResponse);
                }
                else
                {
                    _logger.LogInformation("User registration successful for email: {Email}", request.Email);
                    apiResponse.StatusCode = StatusCodes.Status201Created;
                    apiResponse.Message = ErrorMessages.UserRegistrationSuccess;
                    return StatusCode(apiResponse.StatusCode, apiResponse);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An exception occurred during user registration for email: {Email}", request.Email);
                ErrorHandler.HandleError(ErrorMessages.UserRegistrationFailed, StatusCodes.Status500InternalServerError, ErrorMessages.ErrorOccurredWhileRegistringUser, ref apiResponse);
                return StatusCode(apiResponse.StatusCode, apiResponse);
            }
        }
    }
}
