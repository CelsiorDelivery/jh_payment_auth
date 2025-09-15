using jh_payment_auth.Models;

namespace jh_payment_auth.Services
{
    /// <summary>
    /// This interface defines the contract for token management services, including JWT token generation.
    /// </summary>
    public interface ITokenManagement
    {
        /// <summary>
        /// This method generates a JWT token for the specified user.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        string GenerateJwtToken(string userName);

        /// <summary>
        /// Creates a new refresh token for the specified user.
        /// </summary>
        /// <param name="userName">The name of the user for whom the refresh token is being created. Cannot be null or empty.</param>
        /// <returns>A <see cref="RefreshTokenModel"/> representing the newly created refresh token.</returns>
        RefreshTokenModel CreateRefreshToken(string userName);
    }
}
