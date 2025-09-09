using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace jh_payment_auth.Services
{
    /// <summary>
    /// Class that generates and manages JWT tokens
    /// </summary>
    public class TokenManagementService : ITokenManagement
    {
        private readonly string _secretKey;
        private const string Issuer = "yourdomain.com";
        private const string Audience = "yourdomain.com";

        public TokenManagementService(IConfiguration configuration)
        {
            _secretKey = configuration["Jwt:SecretKey"] ?? throw new ArgumentNullException("Jwt:SecretKey not found in configuration.");
        }

        /// <summary>
        /// Generates JWT token
        /// </summary>
        /// <param name="username"></param>
        /// <returns>JWT token string</returns>
        public string GenerateJwtToken(string username)
        {
            var claims = new[]
            {
                    new Claim(JwtRegisteredClaimNames.Sub, username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: Issuer,
                audience: Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
