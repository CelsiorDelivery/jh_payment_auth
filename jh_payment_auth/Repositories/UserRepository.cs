using jh_payment_auth.Models;
using Microsoft.EntityFrameworkCore;

namespace jh_payment_auth.Repositories
{
    /// <summary>
    /// Implements the <see cref="IUserRepository"/> interface to manage user-related data operations.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly PaymentAuthDbContext _context;

        public UserRepository(PaymentAuthDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Implements a method to check if a user account with the specified account number exists in the system.
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        public async Task<bool> UserAccountExistsAsync(string accountNumber)
        {
            return await _context.Users.AnyAsync(u => u.AccountDetails.AccountNumber == accountNumber);
        }

        /// <summary>
        /// Implements a method to add a new user to the system.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
