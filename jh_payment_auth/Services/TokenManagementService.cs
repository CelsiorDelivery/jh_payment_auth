using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace jh_payment_auth.Services
{
    public class TokenManagementService : ITokenManagement
    {
        private const string SecretKey = "your_super_secret_key";
        private const string Issuer = "yourdomain.com";
        private const string Audience = "yourdomain.com";

        public string GenerateJwtToken(string username)
        {
            var claims = new[]
            {
                    new Claim(JwtRegisteredClaimNames.Sub, username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //var token = new JwtSecurityToken(
            //    issuer: Issuer,
            //    audience: Audience,
            //    claims: claims,
            //    expires: DateTime.UtcNow.AddMinutes(30),
            //    signingCredentials: creds);

            //return new JwtSecurityTokenHandler().WriteToken(token);
            return "";
        }
    }
}
