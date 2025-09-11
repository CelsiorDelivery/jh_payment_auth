using jh_payment_auth.DTOs;

namespace jh_payment_auth.Validators
{
    /// <summary>
    /// This interface defines contracts for validating the requests.
    /// </summary>
    public interface IValidationService
    {
        /// <summary>
        /// This method validates the user registration request to ensure all required fields are present and correctly formatted.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        List<string> ValidateRegistrationRequest(UserRegistrationRequest request);
    }
}
