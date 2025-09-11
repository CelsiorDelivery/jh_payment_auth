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
    }
}
