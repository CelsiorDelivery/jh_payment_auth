using jh_payment_auth.Constants;
using jh_payment_auth.DTOs;
using jh_payment_auth.Models;
using System.Text.RegularExpressions;

namespace jh_payment_auth.Validators
{
    /// <summary>
    /// This service implements the validation logic for user registration requests.
    /// </summary>
    public class ValidationService : IValidationService
    {
        /// <summary>
        /// This method validates the user registration request to ensure all required fields are present and correctly formatted.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public List<string> ValidateRegistrationRequest(UserRegistrationRequest request)
        {
            var errors = new List<string>();

            // Existing validation rules
            if (request.UserId < 0)
                errors.Add(UserErrorMessages.InvalidUserId);

            if (string.IsNullOrWhiteSpace(request.FirstName) || string.IsNullOrWhiteSpace(request.LastName))
                errors.Add(UserErrorMessages.FullNameRequired);

            if (string.IsNullOrWhiteSpace(request.Email) || !Regex.IsMatch(request.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                errors.Add(UserErrorMessages.EmailRequired);

            if (string.IsNullOrWhiteSpace(request.Password) || request.Password.Length < 8)
                errors.Add(UserErrorMessages.PasswordTooShort);

            if (string.IsNullOrWhiteSpace(request.PhoneNumber) || !Regex.IsMatch(request.PhoneNumber, @"^\+?[1-9]\d{1,14}$"))
                errors.Add(UserErrorMessages.PhoneNumberRequired);

            if (request.Age < 18)
                errors.Add(UserErrorMessages.AgeRequirement);


            // New validation rules for address and account details.
            if (request.Address == null)
                errors.Add(UserErrorMessages.AddressRequired);
            else
            {
                if (string.IsNullOrWhiteSpace(request.Address.Street))
                    errors.Add(UserErrorMessages.StreetRequired);
                if (string.IsNullOrWhiteSpace(request.Address.City))
                    errors.Add(UserErrorMessages.CityRequired);
                if (string.IsNullOrWhiteSpace(request.Address.State))
                    errors.Add(UserErrorMessages.StateRequired);
                if (string.IsNullOrWhiteSpace(request.Address.Country))
                    errors.Add(UserErrorMessages.CountryRequired);
                if (string.IsNullOrWhiteSpace(request.Address.ZipCode))
                    errors.Add(UserErrorMessages.ZipCodeRequired);
            }        

            if (request.AccountDetails == null)
                errors.Add(UserErrorMessages.AccountDetailsRequired);
            else
            {
                if (string.IsNullOrWhiteSpace(request.AccountDetails.AccountNumber) || !Regex.IsMatch(request.AccountDetails.AccountNumber, @"^\d{10,12}$"))
                    errors.Add(UserErrorMessages.AccountNumberRequired);
                if (string.IsNullOrWhiteSpace(request.AccountDetails.BankName))
                    errors.Add(UserErrorMessages.BankNameRequired);
                if (string.IsNullOrWhiteSpace(request.AccountDetails.Branch))
                    errors.Add(UserErrorMessages.BranchRequired);
                if (string.IsNullOrWhiteSpace(request.AccountDetails.IFSCCode))
                    errors.Add(UserErrorMessages.InvalidIFSCCode);
                if (string.IsNullOrWhiteSpace(request.AccountDetails.CVV) || request.AccountDetails.CVV.Length < 3)
                    errors.Add(UserErrorMessages.InvalidCVV);
                if (string.IsNullOrWhiteSpace(request.AccountDetails.UPIId) || !request.AccountDetails.UPIId.Contains("@"))
                    errors.Add(UserErrorMessages.InvalidUpi);
                if (request.AccountDetails.DateOfExpiry < DateTime.Now)
                    errors.Add(UserErrorMessages.InvalidDateOfExpiry);
                if (string.IsNullOrWhiteSpace(request.AccountDetails.Nominee))
                    errors.Add(UserErrorMessages.NomineeRequired);
                if (request.AccountDetails.Balance < 999)
                    errors.Add(UserErrorMessages.InitialDepositMinimum);

                // Validate AccountType enum
                if (string.IsNullOrWhiteSpace(request.AccountDetails.AccountType))
                {
                    errors.Add(UserErrorMessages.AccountTypeRequired);
                }
                else if (!Enum.TryParse(request.AccountDetails.AccountType, true, out AccountType _))
                {
                    errors.Add(UserErrorMessages.InvalidAccountType);
                }

                if (string.IsNullOrWhiteSpace(request.AccountDetails.RelationWithNominee))
                {
                    errors.Add(UserErrorMessages.RelationshipRequired);
                }
                else if (!Enum.TryParse(request.AccountDetails.RelationWithNominee, true, out NomineeRelation _))
                {
                    errors.Add(UserErrorMessages.InvalidRelationship);
                }
            }
            return errors;
        }
    }
}
