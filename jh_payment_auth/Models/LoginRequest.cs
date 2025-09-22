﻿using jh_payment_auth.Entity;

namespace jh_payment_auth.Models
{
    /// <summary>
    /// The LoginRequest class represents a request to authenticate a user, containing the necessary
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// Represents the user email of the user attempting to log in.
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// Represents the password of the user attempting to log in.
        /// </summary>
        public string Password { get; set; }
    }

    /// <summary>
    /// The AuthResponse class represents the response returned after a successful authentication,
    /// </summary>
    public class AuthResponse
    {
        /// <summary>
        /// Represents the authentication token issued to the user upon successful login.
        /// </summary>
        public required string AccessToken { get; set; }

        /// <summary>
        /// Represents the refresh token issued to the user for obtaining a new access token when the current one expires.
        /// </summary>
        public required string RefreshToken { get; set; }

        /// <summary>
        /// Represents the expiration datetime of the authentication refresh token.
        /// </summary>
        public DateTime Expiration { get; set; }

        /// <summary>
        /// Userdetail container the user record
        /// </summary>
        public User? UserDetail { set; get; }
    }
}
