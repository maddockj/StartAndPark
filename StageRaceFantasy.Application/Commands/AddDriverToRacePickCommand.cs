using Microsoft.EntityFrameworkCore;
using StartAndPark.Application.Common.Interfaces;
using StartAndPark.Application.Common.Requests;
using StartAndPark.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StartAndPark.Application
{
    public record AddDriverToRacePickCommand(int OwnerId, int RaceId, int DriverId)
        : IApplicationCommand
    {
    }

    public class AddDriverToRacePickHandler : ApplicationRequestHandler<AddDriverToRacePickCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public AddDriverToRacePickHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<ApplicationRequestResult> Handle(AddDriverToRacePickCommand request,
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

            var driverExists = await _dbContext.Drivers
                .AnyAsync(x => x.Id == driverId, cancellationToken);

            if (racePick == null || !driverExists) return NotFound();

            var existingDriver = racePick.RacePickDrivers.FirstOrDefault(x => x.DriverId == driverId);

            if (existingDriver != null) return Success();

            racePick.RacePickDrivers.Add(new RacePickDrivers()
            {
                RacePickId = racePick.Id,
                DriverId = driverId,
            });

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Success();
        }
    }
}
