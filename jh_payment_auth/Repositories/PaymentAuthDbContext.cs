using jh_payment_auth.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace jh_payment_auth.Repositories
{
    /// <summary>
    /// Represents the database context for the Payment Authorization system, providing access to the application's
    /// data.
    /// </summary>
    public class PaymentAuthDbContext: DbContext
    {
        // Constructor to initialize the in-memory database context.
        public PaymentAuthDbContext(DbContextOptions<PaymentAuthDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// DbSet for the User entity. This will be the table in our in-memory database.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// OnModelCreating is used to configure the model that was discovered by convention from the entity types
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // You can add data seeding or model configuration here.
            // For example, to ensure unique IDs:
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Id)
                .IsUnique();
        }
    }
}
