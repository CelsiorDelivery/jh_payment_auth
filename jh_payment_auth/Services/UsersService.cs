using jh_payment_auth.DTOs;
using jh_payment_auth.Helpers;
using jh_payment_auth.Models;
using jh_payment_auth.Repositories;
using jh_payment_auth.Validators;
using Microsoft.AspNetCore.Identity;

namespace jh_payment_auth.Services
{
    /// <summary>
    /// Implements user-related operations, including registration, by interacting with the user repository and validation services.
    /// </summary>
    public class UsersService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidationService _validationService;

        public UsersService(
            IUserRepository userRepository,
            IValidationService validationService)
        {
            _userRepository = userRepository;
            _validationService = validationService;
        }

        /// <summary>
        /// User registration process, including validation, duplication checks, password hashing, and storing user data.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ApiResponse> RegisterUserAsync(UserRegistrationRequest request)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                // Step 1: Validate the incoming request data, including new fields.
                var validationErrors = _validationService.ValidateRegistrationRequest(request);
                if (validationErrors.Count > 0)
                {
                    if (apiResponse.Errors == null)
                        apiResponse.Errors = new List<string>();

                    apiResponse.Errors.AddRange(validationErrors);
                    apiResponse.StatusCode = StatusCodes.Status400BadRequest;
                    return apiResponse;
                }

                // Step 2: Check for existing account number.
                if (await _userRepository.UserAccountExistsAsync(request.AccountDetails.AccountNumber))
                {
                    if (apiResponse.Errors == null)
                        apiResponse.Errors = new List<string>();

                    apiResponse.Errors.Add("User with this account number already exists");
                    apiResponse.StatusCode = StatusCodes.Status400BadRequest;
                    return apiResponse;
                }

                // Step 3: Hash the password for security.
                var hashedPassword = Utility.HashPassword(request.Password);

                // Step 4: Create the new user model, mapping all fields from the request.
                var newUser = new User
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = request.Email,
                    Password = hashedPassword,
                    FullName = request.FullName,
                    Age = request.Age,
                    PhoneNumber = request.PhoneNumber,
                    Address = request.Address,
                    AccountDetails = request.AccountDetails,

                };

                // Step 5: Persist the user data.
                await _userRepository.AddUserAsync(newUser);
            }
            catch (Exception ex)
            {
                if (apiResponse.Errors == null)
                    apiResponse.Errors = new List<string>();

                apiResponse.Errors.Add("An error occurred while processing the request : " + ex);
                apiResponse.StatusCode = StatusCodes.Status500InternalServerError;
            }

            return apiResponse;
        }
    }
}
