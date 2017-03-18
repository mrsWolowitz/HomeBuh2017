using Microsoft.EntityFrameworkCore;
using HomeBuh.Models;

namespace HomeBuh.Data
{
    public class BuhContext: DbContext
    {
        public BuhContext(DbContextOptions<BuhContext> options) : base(options)
        {
        }

    //    protected override void OnModelCreating(ModelBuilder builder)
    //    {
    //        base.OnModelCreating(builder);
    ////        builder.Entity<Entry>()
    ////.Property(b => b.Done)
    ////.HasDefaultValueSql("CONVERT(date, GETDATE())");
    //        // Customize the ASP.NET Identity model and override the defaults if needed.
    //        // For example, you can rename the ASP.NET Identity table names and more.
    //        // Add your customizations after calling base.OnModelCreating(builder);
    //    }

        public DbSet<Entry> Entries { get; set; }
        public DbSet<BuhAccount> BuhAccounts { get; set; }
    }
}
