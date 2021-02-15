using Microsoft.EntityFrameworkCore;
using StartAndPark.Application.Common.Interfaces;
using StartAndPark.Application.Common.Requests;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StartAndPark.Application
{
    public record RemoveDriverFromRacePickCommand(int OwnerId, int RaceId, int DriverId)
        : IApplicationCommand
    {
    }

    public class RemoveDriverFromRacePickHandler : ApplicationRequestHandler<RemoveDriverFromRacePickCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public RemoveDriverFromRacePickHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<ApplicationRequestResult> Handle(RemoveDriverFromRacePickCommand request,
                                                                    CancellationToken cancellationToken)
        {
            var ownerId = request.OwnerId;
            var raceId = request.RaceId;
            var driverId = request.DriverId;

            var racePick = await _dbContext.RacePicks
                .Include(x => x.RacePickDrivers)
                .FirstOrDefaultAsync(
                    x => x.OwnerId == ownerId && x.RaceId == raceId,
                    cancellationToken);

            if (racePick == null) return NotFound();

            var driver = racePick.RacePickDrivers.FirstOrDefault(x => x.DriverId == driverId);

            if (driver == null) return Success();

            racePick.RacePickDrivers.Remove(driver);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Success();
        }
    }
}
