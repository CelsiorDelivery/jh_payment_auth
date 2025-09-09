using jh_payment_auth.Models;

namespace jh_payment_auth.Services
{
    /// <summary>
    /// This interface defines the contract for authentication services, including user validation and login functionality.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// The login method authenticates a user based on the provided login request and returns an authentication response containing a JWT token if successful.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        AuthResponse Login(LoginRequest request);

        /// <summary>
        /// This method validates the user's credentials (username and password) against stored user data.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool ValidateUser(string username, string password);
    }
}
