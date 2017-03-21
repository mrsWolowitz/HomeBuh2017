using Microsoft.EntityFrameworkCore;
using HomeBuh.Models;

namespace HomeBuh.Data
{
    public class BuhContext: DbContext
    {
        public BuhContext(DbContextOptions<BuhContext> options) : base(options)
        {
        }

        public DbSet<Entry> Entries { get; set; }
        public DbSet<BuhAccount> BuhAccounts { get; set; }
        public DbSet<Setting> Settings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entry>()
                .Property(b => b.DateLastUpdate)
                .HasDefaultValueSql("getutcdate()");
        }
    }
}
