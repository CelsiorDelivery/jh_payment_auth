namespace jh_payment_auth.Models
{
    /// <summary>
    /// Represents a user's address, including street, city, state, zip code, and country.
    /// </summary>
    public class UserAddress
    {
        /// <summary>
        /// Gets or sets the street address of the user.
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets the city of the user's address.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the state of the user's address.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the zip code of the user's address.
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Gets or sets the country of the user's address.
        /// </summary>
        public string Country { get; set; }
    }
}
