using Microsoft.EntityFrameworkCore;

namespace RcpgMicroserviceClient.Entities
{
    public class RcpgClientDbContext : DbContext
    {
        public DbSet<Payment> Payments { get; set; }

        public RcpgClientDbContext(DbContextOptions<RcpgClientDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>().HasKey(p => p.Token);
        }
    }
}