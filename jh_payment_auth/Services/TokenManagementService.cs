using jh_payment_auth.Entity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace jh_payment_auth.Services
{
    /// <summary>
    /// Class that generates and manages JWT tokens
    /// </summary>
    public class TokenManagementService : ITokenManagement
    {
        private readonly string _secretKey;
        private readonly string _issuer;
        private readonly string _audience;

        public TokenManagementService(IConfiguration configuration)
        {
            _secretKey = configuration["Jwt:Key"] ?? throw new ArgumentNullException("Jwt:SecretKey not found in configuration.");
            _issuer = configuration["Jwt:Issuer"] ?? throw new ArgumentNullException("Jwt:Issuer not found in configuration.");
            _audience = configuration["Jwt:Audience"] ?? throw new ArgumentNullException("Jwt:Audience not found in configuration.");
        }

        /// <summary>
        /// Generates JWT token
        /// </summary>
        /// <param name="username"></param>
        /// <returns>JWT token string</returns>
        public string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                    //new Claim(JwtRegisteredClaimNames.Sub, user.FirstName),
                    //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    new Claim(ClaimTypes.NameIdentifier, user.FirstName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
