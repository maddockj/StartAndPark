using Microsoft.EntityFrameworkCore;
using StartAndPark.Application.Common.Interfaces;
using StartAndPark.Application.Common.Requests;
using StartAndPark.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StartAndPark.Application
{
    public record SetRacePickCommand(int OwnerId, int RaceId, string Tier, int? EntryId) : IApplicationCommand { }

    public class SetRacePickHandler : ApplicationRequestHandler<SetRacePickCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public SetRacePickHandler(IApplicationDbContext dbContext) { _dbContext = dbContext; }

        public override async Task<ApplicationRequestResult> Handle(SetRacePickCommand request, 
            CancellationToken cancellationToken)
        {
            var ownerId = request.OwnerId;
            var raceId = request.RaceId;
            var tier = request.Tier;
            var entryId = request.EntryId;

            Console.WriteLine($"SetRacePickCommand {request}");

            if (string.IsNullOrWhiteSpace(tier)) return BadRequest();

            var raceOk = await _dbContext.Races.AnyAsync(x => x.Id == raceId, cancellationToken);
            var ownerOk = await _dbContext.Owners.AnyAsync(x => x.Id == ownerId, cancellationToken);
            var entry = await _dbContext.RaceEntries.FindAsync(entryId);
            var entryOk = entryId == null || entry != null;

            if (!raceOk || !ownerOk || !entryOk) return NotFound();

            var existingPick = await _dbContext.RacePicks
                .Include(x => x.RaceEntries)
                .Where(x => x.OwnerId == ownerId && x.RaceId == raceId)
                .FirstOrDefaultAsync();

            var racePick = existingPick ?? new RacePick()
            {
                RaceId = raceId,
                OwnerId = ownerId,
                RaceEntries = new List<RaceEntry>()
            };

            racePick.RaceEntries.RemoveAll(x => x.Tier == tier);

            if (entry != null)
            {
                racePick.RaceEntries.Add(entry);
            }

            if (existingPick == null)
            {
                await _dbContext.RacePicks.AddAsync(racePick, cancellationToken);
            }

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Success();
        }

        public bool RaceEntryExists(int raceId, int teamId)
        {
            return _dbContext.RacePicks
                .Any(x => x.RaceId == raceId && x.OwnerId == teamId);
        }
    }
}
