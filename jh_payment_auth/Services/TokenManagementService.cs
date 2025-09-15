using jh_payment_auth.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
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
        private readonly string _issuer;
        private readonly string _audience;
        private readonly string _accessTokenExpiry;
        private readonly string _refreshTokenExpiryDays;

        /// <summary>
        /// constructor that initializes the TokenManagementService with configuration settings.
        /// </summary>
        /// <param name="configuration"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public TokenManagementService(IConfiguration configuration)
        {
            _secretKey = configuration["Jwt:Key"] ?? throw new ArgumentNullException("Jwt:SecretKey not found in configuration.");
            _issuer = configuration["Jwt:Issuer"] ?? throw new ArgumentNullException("Jwt:Issuer not found in configuration.");
            _audience = configuration["Jwt:Audience"] ?? throw new ArgumentNullException("Jwt:Audience not found in configuration.");
            _accessTokenExpiry = configuration["Jwt:AccessTokenExpiryInSec"] ?? throw new ArgumentNullException("Jwt:AccessTokenExpiryInSec key not found in configuration.");
            _refreshTokenExpiryDays = configuration["Jwt:RefreshTokenExpiryDays"] ?? throw new ArgumentNullException("Jwt:RefreshTokenExpiryDays not found in configuration.");
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

            // Convert seconds to minutes for expiry
            var accessTokenExpirySeconds = Convert.ToDouble(_accessTokenExpiry);
            var accessTokenExpiryMinutes = accessTokenExpirySeconds / 60;

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(accessTokenExpiryMinutes),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// Creates a new refresh token for the specified user.
        /// </summary>
        /// <remarks>The generated refresh token is valid for 7 days from the time of creation. The token
        /// is not revoked by default.</remarks>
        /// <param name="userName">The username for which the refresh token is being created. Cannot be null or empty.</param>
        /// <returns>A <see cref="RefreshTokenModel"/> containing the generated refresh token and its expiration date.</returns>
        public RefreshTokenModel CreateRefreshToken(string userName)
        {
            var refreshToken = new RefreshTokenModel
            {
                RefreshToken = GenerateRefreshToken(),
                Username = userName,
                ExpiryDate = DateTime.UtcNow.AddDays(Convert.ToDouble(_refreshTokenExpiryDays)),
                IsRevoked = false
            };

            return new RefreshTokenModel
            {
                RefreshToken = refreshToken.RefreshToken,
                ExpiryDate = refreshToken.ExpiryDate
            };
        }

        /// <summary>
        /// Generates a cryptographically secure random refresh token.
        /// </summary>
        /// <remarks>The generated token is a Base64-encoded string derived from 32 bytes of random data.
        /// This method uses a cryptographic random number generator to ensure the token's security.</remarks>
        /// <returns>A Base64-encoded string representing the generated refresh token.</returns>
        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }




    }
}
