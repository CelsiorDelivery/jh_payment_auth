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
            if (string.IsNullOrWhiteSpace(request.FullName))
                errors.Add(ErrorMessages.FullNameRequired);

            if (string.IsNullOrWhiteSpace(request.Email) || !Regex.IsMatch(request.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                errors.Add(ErrorMessages.EmailRequired);

            if (string.IsNullOrWhiteSpace(request.Password) || request.Password.Length < 8)
                errors.Add(ErrorMessages.PasswordTooShort);

            if (string.IsNullOrWhiteSpace(request.PhoneNumber) || !Regex.IsMatch(request.PhoneNumber, @"^\+?[1-9]\d{1,14}$"))
                errors.Add(ErrorMessages.PhoneNumberRequired);

            if (request.Age < 18)
                errors.Add(ErrorMessages.AgeRequirement);


            // New validation rules for address and account details.
            if (request.Address == null)
                errors.Add(ErrorMessages.AddressRequired);
            else
            {
                if (string.IsNullOrWhiteSpace(request.Address.Street))
                    errors.Add(ErrorMessages.StreetRequired);
                if (string.IsNullOrWhiteSpace(request.Address.City))
                    errors.Add(ErrorMessages.CityRequired);
                if (string.IsNullOrWhiteSpace(request.Address.State))
                    errors.Add(ErrorMessages.StateRequired);
                if (string.IsNullOrWhiteSpace(request.Address.Country))
                    errors.Add(ErrorMessages.CountryRequired);
                if (string.IsNullOrWhiteSpace(request.Address.ZipCode))
                    errors.Add(ErrorMessages.ZipCodeRequired);
            }        

            if (request.AccountDetails == null)
                errors.Add(ErrorMessages.AccountDetailsRequired);
            else
            {
                if (string.IsNullOrWhiteSpace(request.AccountDetails.AccountNumber) || !Regex.IsMatch(request.AccountDetails.AccountNumber, @"^\d{10,12}$"))
                    errors.Add(ErrorMessages.AccountNumberRequired);
                if (string.IsNullOrWhiteSpace(request.AccountDetails.BankName))
                    errors.Add(ErrorMessages.BankNameRequired);
                if (string.IsNullOrWhiteSpace(request.AccountDetails.Branch))
                    errors.Add(ErrorMessages.BranchRequired);
                if (string.IsNullOrWhiteSpace(request.AccountDetails.Nominee))
                    errors.Add(ErrorMessages.NomineeRequired);
                if (request.AccountDetails.Balance < 999)
                    errors.Add(ErrorMessages.InitialDepositMinimum);

                // Validate AccountType enum
                if (string.IsNullOrWhiteSpace(request.AccountDetails.AccountType))
                {
                    errors.Add(ErrorMessages.AccountTypeRequired);
                }
                else if (!Enum.TryParse(request.AccountDetails.AccountType, true, out AccountType _))
                {
                    errors.Add(ErrorMessages.InvalidAccountType);
                }

                if (string.IsNullOrWhiteSpace(request.AccountDetails.RelationWithNominee))
                {
                    errors.Add(ErrorMessages.RelationshipRequired);
                }
                else if (!Enum.TryParse(request.AccountDetails.RelationWithNominee, true, out NomineeRelation _))
                {
                    errors.Add(ErrorMessages.InvalidRelationship);
                }
            }
            return errors;
        }
    }
}
