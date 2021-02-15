using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StartAndPark.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StartAndPark.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        EntityEntry<T> Entry<T>(T entity) where T : class;
        [Obsolete("Forward cancellation token.")]
        public Task<int> SaveChangesAsync();
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        DbSet<Driver> Drivers { get; set; }
        DbSet<Race> Races { get; set; }
        DbSet<RaceEntry> RaceEntries { get; set; }
        DbSet<Owner> Owners { get; set; }
        DbSet<RacePick> RacePicks { get; set; }
        DbSet<Track> Tracks { get; set; }
    }
}
