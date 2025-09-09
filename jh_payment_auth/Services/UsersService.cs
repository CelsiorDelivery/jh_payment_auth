using jh_payment_auth.Constants;
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
        private readonly ILogger<UsersService> _logger;

        public UsersService(IUserRepository userRepository, ILogger<UsersService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
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
                _logger.LogInformation("Attempting to register new user with email: {Email}", request.Email);
                _logger.LogInformation("Attempting to register new user with Account Number: {AccountNumber}", request.AccountDetails.AccountNumber);
                
                // Step 2: Check for existing account number.
                if (await _userRepository.UserAccountExistsAsync(request.AccountDetails.AccountNumber))
                {
                    ErrorHandler.HandleError(null, StatusCodes.Status400BadRequest, ErrorMessages.UserAccountAlreadyExists, ref apiResponse);
                    _logger.LogError("Registration failed: Account number {AccountNumber} already exists.", request.AccountDetails.AccountNumber);
                    
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
                _logger.LogInformation("User with email: {Email} and Account Number: {AccountNumber} registered successfully.", request.Email, request.AccountDetails.AccountNumber);
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError(null, StatusCodes.Status500InternalServerError, ErrorMessages.ErrorOccurredWhileRegistringUser, ref apiResponse);                
                _logger.LogError(ex, "An error occurred while registering user with account number: {AccountNumber}", request.AccountDetails.AccountNumber);
            }

            return apiResponse;
        }
    }
}
