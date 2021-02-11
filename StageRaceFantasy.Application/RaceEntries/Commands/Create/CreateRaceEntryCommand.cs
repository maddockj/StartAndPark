using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using StageRaceFantasy.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.FantasyTeamRaceEntries.Commands.Create
{
    public record CreateRaceEntryCommand(int OwnerId, int RaceId)
        : IApplicationCommand
    {
    }

    public class CreateRaceEntryHandler : ApplicationRequestHandler<CreateRaceEntryCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateRaceEntryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<ApplicationRequestResult> Handle(
            CreateRaceEntryCommand request,
            CancellationToken cancellationToken)
        {
            var raceId = request.RaceId;
            var ownerId = request.OwnerId;

            if (RaceEntryExists(raceId, ownerId)) return BadRequest();

            var raceExists = await _dbContext.Races.AnyAsync(x => x.Id == raceId, cancellationToken: cancellationToken);
            var ownerExists = await _dbContext.Owners.AnyAsync(x => x.Id == ownerId, cancellationToken: cancellationToken);

            if (!raceExists || !ownerExists) return NotFound();

            var entry = new RaceEntry()
            {
                RaceId = raceId,
                OwnerId = ownerId,
            };

            await _dbContext.RaceEntries.AddAsync(entry, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Success();
        }

        public bool RaceEntryExists(int raceId, int teamId)
        {
            return _dbContext.RaceEntries
                .Any(x => x.RaceId == raceId && x.OwnerId == teamId);
        }
    }
}
