using jh_payment_auth.DTOs;
using jh_payment_auth.Models;

namespace jh_payment_auth.Services
{
    /// <summary>
    /// Defines contract for user-related operations, such as registration.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// User registration process, including validation, duplication checks, password hashing, and storing user data.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ResponseModel</returns>
        Task<ResponseModel> RegisterUserAsync(UserRegistrationRequest request);
    }
}
