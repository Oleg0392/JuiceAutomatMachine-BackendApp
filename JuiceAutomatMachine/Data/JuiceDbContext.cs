using JuiceAutomatMachine.Models;
using Microsoft.EntityFrameworkCore;

namespace JuiceAutomatMachine.Data
{
    public class JuiceDbContext : DbContext
    {
        public JuiceDbContext(DbContextOptions<JuiceDbContext> options) : base(options)
        { 
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder(options);
            optionsBuilder.EnableSensitiveDataLogging(false);
        }

        public DbSet<Juice> Juices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Juice>().ToTable("Juices");
        }
    }
}
