namespace jh_payment_auth.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class AuthResponse
    {
        public string Token { get; set; }
        public string Expiration { get; set; }
    }
}
