using AuthDemoApi.Models;
using jh_payment_auth.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace jh_payment_auth.Services
{
    /// <summary>
    /// This service handles user authentication, including validating user credentials and generating JWT tokens.
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly Dictionary<string, string> _users = new()
        {
            { "admin", "admin123" },
            { "user", "user123" }
        };

        private readonly IConfiguration _config;
        private readonly ITokenManagement _tokenManagement;

        public AuthService(IConfiguration config, ITokenManagement tokenManagement)
        {
            _config = config;
            _tokenManagement = tokenManagement;
        }

        /// <summary>
        /// This method validates the user credentials against a predefined list of users.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool ValidateUser(string username, string password)
        {
            return _users.TryGetValue(username, out var storedPassword) && storedPassword == password;
        }

        /// <summary>
        /// This method handles user login by validating credentials and generating a JWT token upon successful authentication.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public AuthResponse Login(LoginRequest request)
        {
            if (!ValidateUser(request.Username, request.Password))
                return null;
            var validTo = _config["Jwt:ExpiryInSec"] ?? throw new ArgumentNullException("Jwt:expiry not found in configuration.");

            var jwtToken = _tokenManagement.GenerateJwtToken(request.Username);

            var response = new AuthenticateResponse
            {
                Token = jwtToken,
            };

            return new AuthResponse
            {
                Token = jwtToken,
                Expiration = validTo
            };
        }
    }
}
