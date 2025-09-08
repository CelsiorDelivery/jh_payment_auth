namespace jh_payment_auth.Helpers
{
    /// <summary>
    /// Provides utility methods for common operations, such as cryptographic hashing.
    /// </summary>
    public class Utility
    {
        /// <summary>
        /// Computes a secure hash of the specified password using a cryptographic hashing algorithm.
        /// </summary>
        /// <remarks>This method uses a cryptographic hashing algorithm to generate a hash of the input
        /// password.  The resulting hash is encoded as a base64 string for storage or transmission.  Note that this
        /// implementation is for demonstration purposes and may not meet security requirements  for production use.
        /// Consider using a robust password hashing library such as BCrypt or PBKDF2  for secure password
        /// storage.</remarks>
        /// <param name="password">The password to hash. Cannot be null or empty.</param>
        /// <returns>A base64-encoded string representing the hashed password.</returns>
        public static string HashPassword(string password)
        {
            // Implement a secure hashing algorithm here, e.g., BCrypt, PBKDF2, etc.
            // For demonstration purposes, we'll use a simple hash (not secure for production).
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
