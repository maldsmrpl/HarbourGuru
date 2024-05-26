using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HarbourGuru.MVC.Models;

namespace HarbourGuru.MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Harbour> Harbours { get; set; }
        public DbSet<HarbourCard> HarbourCards { get; set; }
        public DbSet<HarbourCardCategory> HarbourCardCategories { get; set; }
        public DbSet<HarbourCardPhone> HarbourCardPhones { get; set; }
        public DbSet<HarbourCardReview> HarbourCardReviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(modelBuilder);

            // Example: setting up composite keys or other configurations
            // modelBuilder.Entity<YourEntity>().HasKey(e => new { e.Key1, e.Key2 });

            modelBuilder.Entity<Country>()
                .HasMany(c => c.Harbours)
                .WithOne(h => h.Country)
                .HasForeignKey(h => h.CountryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Harbour>()
                .HasMany(h => h.HarbourCards)
                .WithOne(hc => hc.Harbour)
                .HasForeignKey(hc => hc.HarbourId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<HarbourCard>()
                .HasMany(hc => hc.Phones)
                .WithOne(p => p.HarbourCard)
                .HasForeignKey(p => p.HarbourCardId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<HarbourCard>()
                .HasMany(hc => hc.Reviews)
                .WithOne(r => r.HarbourCard)
                .HasForeignKey(r => r.HarbourCardId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AppUser>()
                .HasMany(u => u.Reviews)
                .WithOne(r => r.AppUser)
                .HasForeignKey(r => r.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
