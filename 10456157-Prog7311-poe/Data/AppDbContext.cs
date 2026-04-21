using _10456157_Prog7311_poe.Models;
using Microsoft.EntityFrameworkCore;

namespace _10456157_Prog7311_poe.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contract>()
                .HasOne(c => c.Client)
                .WithMany(c => c.Contracts)
                .HasForeignKey(c => c.ClientId);

            modelBuilder.Entity<ServiceRequest>()
                .HasOne(s => s.Contract)
                .WithMany(c => c.ServiceRequests)
                .HasForeignKey(s => s.ContractId);
        }
    }
}
