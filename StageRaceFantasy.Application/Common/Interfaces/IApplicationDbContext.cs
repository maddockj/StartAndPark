﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StageRaceFantasy.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        EntityEntry<T> Entry<T>(T entity) where T : class;
        [Obsolete("Forward cancellation token.")]
        public Task<int> SaveChangesAsync();
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        DbSet<Driver> Drivers { get; set; }
        DbSet<Race> Races { get; set; }
        DbSet<DriverRaceEntry> DriverRaceEntries { get; set; }
        DbSet<Owner> Owners { get; set; }
        DbSet<RaceEntry> RaceEntries { get; set; }
    }
}
