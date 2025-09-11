using jh_payment_auth.Models;

namespace jh_payment_auth.Services.Services
{
    public interface IAuthService
    {
        AuthResponse Login(LoginRequest request);
        bool ValidateUser(string username, string password);
    }
}
