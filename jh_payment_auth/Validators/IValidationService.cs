using jh_payment_auth.DTOs;

namespace jh_payment_auth.Validators
{
    public interface IValidationService
    {
        List<string> ValidateRegistrationRequest(UserRegistrationRequest request);
    }
}
