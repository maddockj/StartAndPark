using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.FantasyTeamRaceEntries.Commands.Delete
{
    public record DeleteRaceEntryCommand(int OwnerId, int RaceId)
        : IApplicationCommand
    {
    }

    public class DeleteRaceEntryHandler : ApplicationRequestHandler<DeleteRaceEntryCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteRaceEntryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<ApplicationRequestResult> Handle(DeleteRaceEntryCommand request, CancellationToken cancellationToken)
        {
            var ownerId = request.OwnerId;
            var raceId = request.RaceId;

            var entry = await _dbContext.RaceEntries
                .FirstOrDefaultAsync(
                    x => x.OwnerId == ownerId && x.RaceId == raceId,
                    cancellationToken);

            if (entry == null) return NotFound();

            _dbContext.RaceEntries.Remove(entry);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Success();
        }
    }
}
