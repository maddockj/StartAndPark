using Microsoft.EntityFrameworkCore;
using StartAndPark.Application.Common.Interfaces;
using StartAndPark.Application.Common.Requests;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StartAndPark.Application
{
    public record RemoveDriverFromRaceEntryCommand(int OwnerId, int RaceId, int DriverId)
        : IApplicationCommand
    {
    }

    public class RemoveDriverFromRaceEntryHandler : ApplicationRequestHandler<RemoveDriverFromRaceEntryCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public RemoveDriverFromRaceEntryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<ApplicationRequestResult> Handle(RemoveDriverFromRaceEntryCommand request,
                                                                    CancellationToken cancellationToken)
        {
            var ownerId = request.OwnerId;
            var raceId = request.RaceId;
            var driverId = request.DriverId;

            var raceEntry = await _dbContext.RaceEntries
                .Include(x => x.RaceEntryDrivers)
                .FirstOrDefaultAsync(
                    x => x.OwnerId == ownerId && x.RaceId == raceId,
                    cancellationToken);

            if (raceEntry == null) return NotFound();

            var driver = raceEntry.RaceEntryDrivers.FirstOrDefault(x => x.DriverId == driverId);

            if (driver == null) return Success();

            raceEntry.RaceEntryDrivers.Remove(driver);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Success();
        }
    }
}
