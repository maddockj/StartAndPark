using Microsoft.EntityFrameworkCore;
using StartAndPark.Application.Common.Interfaces;
using StartAndPark.Application.Common.Requests;
using StartAndPark.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StartAndPark.Application
{
    public record CreateRacePickCommand(int OwnerId, int RaceId)
        : IApplicationCommand
    {
    }

    public class CreateRacePickHandler : ApplicationRequestHandler<CreateRacePickCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateRacePickHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<ApplicationRequestResult> Handle(
            CreateRacePickCommand request,
            CancellationToken cancellationToken)
        {
            var raceId = request.RaceId;
            var ownerId = request.OwnerId;

            if (RaceEntryExists(raceId, ownerId)) return BadRequest();

            var raceExists = await _dbContext.Races.AnyAsync(x => x.Id == raceId, cancellationToken: cancellationToken);
            var ownerExists = await _dbContext.Owners.AnyAsync(x => x.Id == ownerId, cancellationToken: cancellationToken);

            if (!raceExists || !ownerExists) return NotFound();

            var racePick = new RacePick()
            {
                RaceId = raceId,
                OwnerId = ownerId,
            };

            await _dbContext.RacePicks.AddAsync(racePick, cancellationToken);
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
