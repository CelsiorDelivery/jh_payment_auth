using System.ComponentModel.DataAnnotations;

namespace jh_payment_auth.Models
{
    public class RefreshTokenModel
    {
        [Required]
        public string RefreshToken { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }
        public bool? IsRevoked { get; set; }
    }
}
