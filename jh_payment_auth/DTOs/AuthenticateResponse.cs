namespace AuthDemoApi.Models
{
    /// <summary>
    /// The response returned after a successful authentication, containing the JWT token.
    /// </summary>
    public class AuthenticateResponse
    {
        /// <summary>
        /// The JWT token issued upon successful authentication.
        /// </summary>
        public string Token { get; set; }
    }
}
