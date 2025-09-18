namespace jh_payment_auth.Constants
{
    /// <summary>
    /// This static class contains constant user related error message and code strings used throughout the application
    /// </summary>
    public class UserErrorMessages
    {
        public const string UserAlreadyExistsCode = "USR001";
        public const string UserAccountAlreadyExists = "An user with this email already exists.";
        public const string UserValidationFailedCode = "COM001";
        public const string UserValidationFailed = "User request validation failed.";
        public const string UserRegistrationFailedCode = "USR002";
        public const string UserRegistrationFailed = "User registration failed.";
        public const string ErrorOccurredWhileRegistringUserCode = "USR003";
        public const string ErrorOccurredWhileRegistringUser = "An error occurred while registering user";
        public const string UserRegistrationSuccess = "User registered successfully.";

        // Validation Messages
        public const string InvalidUserId = "User id is invalid";
        public const string FullNameRequired = "Full name is required.";
        public const string EmailRequired = "A valid email address is required.";
        public const string PasswordTooShort = "Password must be at least 8 characters long.";
        public const string PhoneNumberRequired = "A valid phone number is required.";
        public const string AgeRequirement = "User must be at least 18 years old.";

        // Address Details Validation Messages
        public const string AddressRequired = "Address is required.";
        public const string StreetRequired = "Street is required.";
        public const string CityRequired = "City is required.";
        public const string StateRequired = "State is required.";
        public const string CountryRequired = "Country is required.";
        public const string ZipCodeRequired = "Zip code is required.";

        // Account Details Validation Messages
        public const string AccountDetailsRequired = "Account details are required.";
        public const string AccountNumberRequired = "A valid account number (10-12 digits) is required.";
        public const string BankNameRequired = "Bank name is required.";
        public const string BranchRequired = "Branch is required.";
        public const string InvalidIFSCCode = "IFSC code is invalid";
        public const string InvalidCVV = "CVV is invalid";
        public const string InvalidUpi = "UPI id is invalid";
        public const string InvalidDateOfExpiry = "Date of expiry is invalid";
        public const string NomineeRequired = "Nominee is required.";
        public const string RelationshipRequired = "Relationship with nominee is required.";
        public const string InvalidRelationship = "Invalid Relation with nominee provided. Valid types are: Father, Mother, Spouse, Husband, Brother, Sister, Child";
        public const string AccountTypeRequired = "Account type is required.";
        public const string InvalidAccountType = "Invalid account type provided. Valid types are: Saving, Checking, Loan, Business.";        
        public const string InitialDepositMinimum = "Initial deposit must be at least $1000.";

    }
}
