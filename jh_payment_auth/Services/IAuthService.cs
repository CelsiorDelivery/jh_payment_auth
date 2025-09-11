using jh_payment_auth.Models;

namespace jh_payment_auth.Services
{
    public interface IAuthService
    {
        Task<ResponseModel> Login(LoginRequest request);
        Task<bool> ValidateUser(string username, string password);
    }
}
