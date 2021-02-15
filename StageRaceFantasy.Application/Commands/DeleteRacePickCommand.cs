using Microsoft.EntityFrameworkCore;
using StartAndPark.Application.Common.Interfaces;
using StartAndPark.Application.Common.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace StartAndPark.Application
{
    public record DeleteRacePickCommand(int OwnerId, int RaceId)
        : IApplicationCommand
    {
    }

    public class DeleteRacePickHandler : ApplicationRequestHandler<DeleteRacePickCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteRacePickHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<ApplicationRequestResult> Handle(DeleteRacePickCommand request, CancellationToken cancellationToken)
        {
            var ownerId = request.OwnerId;
            var raceId = request.RaceId;

            var racePick = await _dbContext.RacePicks
                .FirstOrDefaultAsync(
                    x => x.OwnerId == ownerId && x.RaceId == raceId,
                    cancellationToken);

            if (racePick == null) return NotFound();

            _dbContext.RacePicks.Remove(racePick);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Success();
        }
    }
}
