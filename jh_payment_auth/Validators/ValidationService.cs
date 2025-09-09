using jh_payment_auth.DTOs;
using jh_payment_auth.Models;
using System.Text.RegularExpressions;

namespace jh_payment_auth.Validators
{
    public class ValidationService : IValidationService
    {
        public List<string> ValidateRegistrationRequest(UserRegistrationRequest request)
        {
            var errors = new List<string>();

            // Existing validation rules
            if (string.IsNullOrWhiteSpace(request.FullName))
                errors.Add("First name is required.");

            if (string.IsNullOrWhiteSpace(request.Email) || !Regex.IsMatch(request.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                errors.Add("A valid email address is required.");

            if (string.IsNullOrWhiteSpace(request.Password) || request.Password.Length < 8)
                errors.Add("Password must be at least 8 characters long.");

            if (string.IsNullOrWhiteSpace(request.PhoneNumber) || !Regex.IsMatch(request.PhoneNumber, @"^\+?[1-9]\d{1,14}$"))
                errors.Add("A valid phone number is required.");

            if (request.Age < 18)
                errors.Add("User must be at least 18 years old.");


            // New validation rules for address and account details.
            if (request.Address == null)
                errors.Add("Address is required.");
            else
            {
                if (string.IsNullOrWhiteSpace(request.Address.Street))
                    errors.Add("Street is required.");
                if (string.IsNullOrWhiteSpace(request.Address.City))
                    errors.Add("City is required.");
                if (string.IsNullOrWhiteSpace(request.Address.State))
                    errors.Add("State is required.");
                if (string.IsNullOrWhiteSpace(request.Address.Country))
                    errors.Add("Country is required.");
                if (string.IsNullOrWhiteSpace(request.Address.ZipCode))
                    errors.Add("Zip code is required.");
            }        

            if (request.AccountDetails == null)
                errors.Add("Account details are required.");
            else
            {
                if (string.IsNullOrWhiteSpace(request.AccountDetails.AccountNumber) || !Regex.IsMatch(request.AccountDetails.AccountNumber, @"^\d{10,12}$"))
                    errors.Add("A valid account number (10-12 digits) is required.");
                if (string.IsNullOrWhiteSpace(request.AccountDetails.BankName))
                    errors.Add("Bank name is required.");
                if (string.IsNullOrWhiteSpace(request.AccountDetails.Branch))
                    errors.Add("Branch is required.");
                if (string.IsNullOrWhiteSpace(request.AccountDetails.Nominee))
                    errors.Add("Nominee is required.");
                if (request.AccountDetails.Balance < 0)
                    errors.Add("Balance cannot be negative.");

                // Validate AccountType enum
                if (string.IsNullOrWhiteSpace(request.AccountDetails.AccountType))
                {
                    errors.Add("Account type is required.");
                }
                else if (!Enum.TryParse(request.AccountDetails.AccountType, true, out AccountType _))
                {
                    errors.Add("Invalid account type provided. Valid types are: Saving, Checking, Loan, Business.");
                }

                if (string.IsNullOrWhiteSpace(request.AccountDetails.RelationWithNominee))
                {
                    errors.Add("Relation with nominee is required.");
                }
                else if (!Enum.TryParse(request.AccountDetails.RelationWithNominee, true, out NomineeRelation _))
                {
                    errors.Add("Invalid Relation with nominee provided. Valid types are: Father, Mother, Spouse, Husband, Brother, Sister, Child");
                }
            }
            return errors;
        }
    }
}
