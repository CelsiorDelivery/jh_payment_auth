namespace jh_payment_auth.Services
{
    /// <summary>
    /// Generates and manages JWT tokens
    /// </summary>
    public interface ITokenManagement
    {
        string GenerateJwtToken(string userName);
    }
}
