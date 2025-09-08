using jh_payment_auth.Models;

namespace jh_payment_auth.Repositories
{
    /// <summary>
    /// Defines a contract for managing user-related data operations.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Determines whether a user account with the specified account number exists in the system.
        /// </summary>
        /// <param name="accountNumber">The account number of the user to check. Cannot be null or empty.</param>
        /// <returns><see langword="true"/> if a user with the specified account number exists; otherwise, <see
        /// langword="false"/>.</returns>
        Task<bool> UserAccountExistsAsync(string accountNumber);

        /// <summary>
        /// Asynchronously adds a new user to the system.
        /// </summary>
        /// <param name="user">The user to add. Must not be <see langword="null"/>.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task AddUserAsync(User user);
    }
}
