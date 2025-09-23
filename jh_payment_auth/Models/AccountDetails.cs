using jh_payment_auth.Entity;

namespace jh_payment_auth.Models
{
    /// <summary>
    /// Represents the bank account details associated with a user, including account number, bank name,
    /// </summary>
    public class AccountDetails
    {
        /// <summary>
        /// Gets or sets the unique account number.
        /// </summary>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the name of the bank.
        /// </summary>
        public string BankName { get; set; }

        public string BankCode { set; get; }

        /// <summary>
        /// Gets or sets the branch of the bank.
        /// </summary>
        public string Branch { get; set; }

        /// <summary>
        /// Represents the Indian Financial System Code (IFSC) of the bank branch.
        /// </summary>
        public string IFSCCode { get; set; }

        /// <summary>
        /// Represents the CVV
        /// </summary>
        public string CVV { get; set; }

        /// <summary>
        /// Represents the UPI id
        /// </summary>
        public string UPIId { get; set; }

        /// <summary>
        /// Represents the Expiry for CVV
        /// </summary>
        public DateTime DateOfExpiry { get; set; }

        /// <summary>
        /// Gets or sets the type of the account (e.g., Savings, Checking, Loan, Business).
        /// </summary>
        public AccountType AccountType { get; set; }

        /// <summary>
        /// Gets or sets the name of the nominee associated with the account.
        /// </summary>
        public string Nominee { get; set; }

        /// <summary>
        /// Gets or sets the relationship of the nominee to the account holder(e.g., Father, Mother, Spouse, Husband, Brother, Sister, Child).
        /// </summary>
        public NomineeRelation RelationWithNominee { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the account is active.
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Gets or sets the current balance of the account.
        /// </summary>
        public decimal Balance { get; set; }
    }

    /// <summary>
    /// An enumeration representing different types of bank accounts.
    /// </summary>
    public enum AccountType
    {
        Saving,
        Checking,
        Loan,
        Business
    }

    /// <summary>
    /// An enumeration representing the relationship of a nominee to the account holder.
    /// </summary>
    public enum NomineeRelation
    {
        Father,
        Mother,
        Brother,
        Sister,
        Spouse,
        Child,
        Husband,
    }
}
