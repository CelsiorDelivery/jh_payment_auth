using jh_payment_auth.Entity;

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
        /// <param name="user"></param>
        /// <returns></returns>
        string GenerateJwtToken(User user);
    }
}
