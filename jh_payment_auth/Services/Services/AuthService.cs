using AuthDemoApi.Models;
using jh_payment_auth.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace jh_payment_auth.Services
{
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

        public bool ValidateUser(string username, string password)
        {
            return _users.TryGetValue(username, out var storedPassword) && storedPassword == password;
        }

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
