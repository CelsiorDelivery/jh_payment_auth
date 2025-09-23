using jh_payment_auth.Constants;
using jh_payment_auth.DTOs;
using jh_payment_auth.Entity;
using jh_payment_auth.Helpers;
using jh_payment_auth.Models;
using jh_payment_auth.Validators;

namespace jh_payment_auth.Services
{
    /// <summary>
    /// Implements user-related operations, including registration, by interacting with the user repository and validation services.
    /// </summary>
    public class UsersService : IUserService
    {
        private readonly ILogger<UsersService> _logger;
        private readonly IValidationService _validationService;
        private readonly IHttpClientService _httpClientService;

        public UsersService(ILogger<UsersService> logger,
            IValidationService validationService, IHttpClientService httpClientService)
        {
            _logger = logger;
            _validationService = validationService;
            _httpClientService = httpClientService;
        }

        /// <summary>
        /// User registration process, including validation, duplication checks, password hashing, and storing user data.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ResponseModel> RegisterUserAsync(UserRegistrationRequest request)
        {
            try
            {
                _logger.LogInformation("Attempting to register new user with email: {Email}", request.Email);
                _logger.LogInformation("Attempting to register new user with Account Number: {AccountNumber}", request.AccountDetails.AccountNumber);

                // Step 1: Validate the incoming request data, including new fields.
                var validationErrors = _validationService.ValidateRegistrationRequest(request);
                if (validationErrors.Count > 0)
                {
                    _logger.LogError("User registration validation failed: {Errors}", string.Join(", ", validationErrors));
                    return ErrorResponseModel.BadRequest(UserErrorMessages.UserValidationFailed + " Validation Errors: \n" + string.Join(", ", validationErrors), UserErrorMessages.UserValidationFailedCode);
                }

                // Step 2: Check for existing user.
                var user = await GetUserData(request.Email);
                if (user != null)
                {
                    _logger.LogError("Registration failed: User with the id {UserId} already exists.", request.UserId);
                    return ErrorResponseModel.BadRequest(UserErrorMessages.UserAccountAlreadyExists, UserErrorMessages.UserAlreadyExistsCode);
                }

                // Step 3: Hash the password for security.
                var hashedPassword = Utility.HashPassword(request.Password);

                // Step 4: Create the new user model, mapping all fields from the request.
                var newUser = new User
                {
                    UserId = request.UserId,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Password = hashedPassword,
                    Age = request.Age,
                    Mobile = request.PhoneNumber,
                    Address = request.Address.Street,
                    City = request.Address.City,
                    AccountNumber = request.AccountDetails.AccountNumber,
                    BankName = request.AccountDetails.BankName,
                    IFCCode = request.AccountDetails.IFSCCode,
                    BankCode = request.AccountDetails.BankCode,
                    Branch = request.AccountDetails.Branch,
                    IsActive = true,
                    CVV = request.AccountDetails.CVV,
                    DateOfExpiry = request.AccountDetails.DateOfExpiry,
                    UPIID = request.AccountDetails.UPIId,
                    Role = request.Role,
                    Balance = request.AccountDetails.Balance
                };

                // Step 5: Persist the user data.
                var response = await AddUserData(newUser);
                if (response == null)
                {
                    _logger.LogError("User registration failed for email: {Email} and Account Number: {AccountNumber}", request.Email, request.AccountDetails.AccountNumber);
                    return ErrorResponseModel.InternalServerError(UserErrorMessages.UserRegistrationFailed, UserErrorMessages.UserRegistrationFailedCode);
                }

                _logger.LogInformation("User with email: {Email} and Account Number: {AccountNumber} registered successfully.", request.Email, request.AccountDetails.AccountNumber);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while registering user with account number: {AccountNumber}", request.AccountDetails.AccountNumber);
                return ErrorResponseModel.InternalServerError(UserErrorMessages.ErrorOccurredWhileRegistringUser, UserErrorMessages.ErrorOccurredWhileRegistringUserCode);
            }

            return ResponseModel.Ok(request,UserErrorMessages.UserRegistrationSuccess);
        }

        private async Task<ResponseModel> AddUserData(User user)
        {
            try
            {
                return await _httpClientService.PostAsync<User, ResponseModel>("v1/perops/user/adduser", user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while adding User:");
            }
            return null;
        }

        private async Task<User> GetUserData(string email)
        {
            try
            {
                return await _httpClientService.GetAsync<User>("v1/perops/user/getuser/" + email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "User not found");
            }
            return null;
        }
    }
}
