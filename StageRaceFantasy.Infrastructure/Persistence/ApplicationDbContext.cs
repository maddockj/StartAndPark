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
        public DbSet<RaceEntry> DriverRaceEntries { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<RacePick> RacePicks { get; set; }
        public DbSet<Track> Tracks { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RaceEntry>()
                .HasKey(x => new { x.RaceId, x.DriverId });

            modelBuilder.Entity<RacePick>()
                .HasAlternateKey(x => new { x.OwnerId, x.RaceId });

            modelBuilder.Entity<RacePickDrivers>()
                .HasKey(x => new { x.RacePickId, x.DriverId });

            modelBuilder.Entity<RacePickDrivers>()
                .HasOne(x => x.RacePick)
                .WithMany(x => x.RacePickDrivers)
                .HasForeignKey(x => x.RacePickId);

            modelBuilder.Entity<RacePickDrivers>()
                .HasOne(x => x.Driver)
                .WithMany(x => x.RacePickDrivers)
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
