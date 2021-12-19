using Microsoft.EntityFrameworkCore;

namespace Payment.Infrastructure.DataContext
{
    public class PaymentDbContext : DbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Entities.Payment> Payments { get; set; }
    }
}
