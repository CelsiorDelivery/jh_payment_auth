namespace jh_payment_auth.Services
{
    public interface ITokenManagement
    {
        string GenerateJwtToken(string userName);
    }
}
