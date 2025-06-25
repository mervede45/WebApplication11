using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace WebApplication11.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<PasswordEntry> PasswordEntries { get; set; }
        public DbSet<Category> Categories { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Table names
            modelBuilder.Entity<PasswordEntry>().ToTable("PasswordEntries");
            modelBuilder.Entity<Category>().ToTable("Categories");
        }
    }
}