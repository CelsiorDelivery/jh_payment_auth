namespace jh_payment_auth.Services
{
    interface ITokenManagement
    {
        string GenerateJwtToken(string userName);
    }
}
