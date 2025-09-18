using System.Data;
using System.Text.Json.Serialization;

namespace jh_payment_auth.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class User
    {
        /// <summary>
        /// Represents User ID
        /// </summary>
        public long UserId { set; get; }

        /// <summary>
        /// Represents the user's first name
        /// </summary>
        public string FirstName { set; get; }

        /// <summary>
        /// Represents the user's last name
        /// </summary>
        public string LastName { set; get; }

        /// <summary>
        /// Represents the password for the user's account.
        /// </summary>
        [JsonIgnore]
        public string Password { set; get; }

        /// <summary>
        /// Represents the age of the user.
        /// </summary>
        public int Age { set; get; }

        /// <summary>
        /// Represents the email address of the user.
        /// </summary>
        public string Email { set; get; }

        /// <summary>
        /// Represents the mobile number of the user.
        /// </summary>
        public string Mobile { set; get; }

        /// <summary>
        /// Represents the address of the user.
        /// </summary>
        public string Address { set; get; }

        /// <summary>
        /// Represents the account number of the user.
        /// </summary>
        public string AccountNumber { set; get; }

        /// <summary>
        /// Represents the bank name of the user.
        /// </summary>
        public string BankName { set; get; }

        /// <summary>
        /// Represents the IFSC code of the user's bank.
        /// </summary>
        public string IFCCode { set; get; }

        /// <summary>
        /// Represents the bank code of the user's bank.
        /// </summary>
        public string BankCode { set; get; }

        /// <summary>
        /// Represents the city where the user resides.
        /// </summary>
        public string City { set; get; }

        /// <summary>
        /// Represents the branch of the user's bank.
        /// </summary>
        public string Branch { set; get; }

        /// <summary>
        /// Represents the UPI ID of the user.
        /// </summary>
        public string UPIID { set; get; }

        /// <summary>
        /// Represents the CVV number of the user.
        /// </summary>
        public string CVV { set; get; }

        /// <summary>
        /// Represents whether the user's account is active.
        /// </summary>
        public bool IsActive { set; get; }

        //[JsonConverter(typeof(JsonStringEnumConverter))]
        public Roles Role { set; get; } = Roles.User;

        /// <summary>
        /// Represents the expiry date for CVV.
        /// </summary>
        public DateTime DateOfExpiry { set; get; }
    }

    public enum Roles
    {
        User,
        Admin,
        Merchant
    }
}
