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
    //public record SetRacePickCommand(int OwnerId, int RaceId, string Tier, int? NewEntryId, int? OldEntryId) : IApplicationCommand { }
    public record SetRacePickCommand(int OwnerId, int RaceId, List<int> RaceEntryIds) : IApplicationCommand { }

    public class SetRacePickHandler : ApplicationRequestHandler<SetRacePickCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public SetRacePickHandler(IApplicationDbContext dbContext) { _dbContext = dbContext; }

        public override async Task<ApplicationRequestResult> Handle(SetRacePickCommand request, 
            CancellationToken cancellationToken)
        {
            var ownerId = request.OwnerId;
            var raceId = request.RaceId;
            //var tier = request.Tier;
            //var newEntryId = request.NewEntryId;
            //var oldEntryId = request.OldEntryId;
            var raceEntryIds = request.RaceEntryIds;

            Console.WriteLine($"SetRacePickCommand {request}");

            //if (string.IsNullOrWhiteSpace(tier)) return BadRequest();
            if (raceEntryIds == null) return BadRequest();

            var raceOk = await _dbContext.Races.AnyAsync(x => x.Id == raceId, cancellationToken);
            var ownerOk = await _dbContext.Owners.AnyAsync(x => x.Id == ownerId, cancellationToken);
            //var entry = await _dbContext.RaceEntries.FindAsync(newEntryId);
            //var entryOk = newEntryId == null || entry != null;
            List<RaceEntry> entries = await _dbContext.RaceEntries
                .Where(x => raceEntryIds.Contains(x.Id))
                .ToListAsync();

            var entriesOk = raceEntryIds.Count == entries.Count;

            if (!raceOk || !ownerOk || !entriesOk) return NotFound();

            var racePick = await _dbContext.RacePicks
                .Include(x => x.RaceEntries)
                .Where(x => x.OwnerId == ownerId && x.RaceId == raceId)
                .FirstOrDefaultAsync();

            if (racePick == null)
            {
                racePick = new RacePick()
                {
                    RaceId = raceId,
                    OwnerId = ownerId,
                    RaceEntries = entries
                };

                await _dbContext.RacePicks.AddAsync(racePick, cancellationToken);
            }
            else
            {
                racePick.RaceEntries = entries;
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
