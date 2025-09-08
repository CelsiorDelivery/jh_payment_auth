using jh_payment_auth.Models;
using System.Net;

namespace jh_payment_auth.DTOs
{
    /// <summary>
    /// Represents a request to register a new user, containing the user's personal, contact, and account details.
    /// </summary>
    public class UserRegistrationRequest
    {
        /// <summary>
        /// Gets or sets the full name of the user.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the age of the user.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password for the user's account.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the user.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the address of the user.
        /// </summary>
        public UserAddress Address { get; set; }

        /// <summary>
        /// Gets or sets the account details of the user.
        /// </summary>
        public AccountDetails AccountDetails { get; set; }
    }
}
