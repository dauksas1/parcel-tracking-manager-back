using Microsoft.EntityFrameworkCore;
using ParcelTrackingManager.Models;

namespace ParcelTrackingManager.Data
{
    public class ParcelContext : DbContext
    {
        public ParcelContext(DbContextOptions<ParcelContext> options) : base(options) { }

        public DbSet<Parcel> Parcels { get; set; }
        public DbSet<StatusEntry> StatusEntries { get; set; } // Add this line

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Owned types for embedded sender/recipient
            modelBuilder.Entity<Parcel>().OwnsOne(p => p.Sender);
            modelBuilder.Entity<Parcel>().OwnsOne(p => p.Recipient);

            // One-to-many relationship for status history
            modelBuilder.Entity<Parcel>()
                .HasMany(p => p.StatusHistory)
                .WithOne(h => h.Parcel)
                .HasForeignKey(h => h.ParcelId);
        }
    }
}




