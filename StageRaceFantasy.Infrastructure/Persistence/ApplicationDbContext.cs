using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StartAndPark.Application.Common.Interfaces;
using StartAndPark.Domain.Entities;
using System.Threading.Tasks;

namespace StartAndPark.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<DriverRaceEntry> DriverRaceEntries { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<RaceEntry> RaceEntries { get; set; }
        public DbSet<Track> Tracks { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DriverRaceEntry>()
                .HasKey(x => new { x.RaceId, x.DriverId });

            modelBuilder.Entity<RaceEntry>()
                .HasAlternateKey(x => new { x.OwnerId, x.RaceId });

            modelBuilder.Entity<RaceEntryDriver>()
                .HasKey(x => new { x.RaceEntryId, x.DriverId });

            modelBuilder.Entity<RaceEntryDriver>()
                .HasOne(x => x.RaceEntry)
                .WithMany(x => x.RaceEntryDrivers)
                .HasForeignKey(x => x.RaceEntryId);

            modelBuilder.Entity<RaceEntryDriver>()
                .HasOne(x => x.Driver)
                .WithMany(x => x.RaceEntryDrivers)
                .HasForeignKey(x => x.DriverId);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public override EntityEntry<T> Entry<T>(T entity) where T : class
        {
            return base.Entry<T>(entity);
        }
    }
}
