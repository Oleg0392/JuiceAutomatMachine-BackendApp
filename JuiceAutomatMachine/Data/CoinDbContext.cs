using JuiceAutomatMachine.Models;
using Microsoft.EntityFrameworkCore;

namespace JuiceAutomatMachine.Data
{
    public class CoinDbContext : DbContext
    {
        public CoinDbContext(DbContextOptions<CoinDbContext> options) : base(options) { }

        public DbSet<Coin> Coins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coin>().ToTable("Coins");
        }
    }
}
