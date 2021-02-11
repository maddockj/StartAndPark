using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.RiderRaceEntries.Commands.Delete
{
    public record DeleteDriverRaceEntryCommand(int RaceId, int DriverId) :
        IApplicationCommand
    {
    }

    public class DeleteDriverRaceEntryHandler : ApplicationRequestHandler<DeleteDriverRaceEntryCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteDriverRaceEntryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<ApplicationRequestResult> Handle(DeleteDriverRaceEntryCommand request, CancellationToken cancellationToken)
        {
            var raceId = request.RaceId;
            var driverId = request.DriverId;

            var driverRaceEntry = await _dbContext.DriverRaceEntries
                .FindAsync(new object[] { raceId, driverId }, cancellationToken: cancellationToken);

            if (driverRaceEntry == null) return NotFound();

            _dbContext.DriverRaceEntries.Remove(driverRaceEntry);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Success();
        }
    }
}
