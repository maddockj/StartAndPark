using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using StageRaceFantasy.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.Commands.FanasyTeamRaceEntries
{
    public record AddDriverToRaceEntryCommand(int OwnerId, int RaceId, int DriverId)
        : IApplicationCommand
    {
    }

    public class AddDriverToRaceEntryHandler : ApplicationRequestHandler<AddDriverToRaceEntryCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public AddDriverToRaceEntryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<ApplicationRequestResult> Handle(AddDriverToRaceEntryCommand request,
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

            var driverExists = await _dbContext.Drivers
                .AnyAsync(x => x.Id == driverId, cancellationToken);

            if (raceEntry == null || !driverExists) return NotFound();

            var existingDriver = raceEntry.RaceEntryDrivers.FirstOrDefault(x => x.DriverId == driverId);

            if (existingDriver != null) return Success();

            raceEntry.RaceEntryDrivers.Add(new RaceEntryDriver()
            {
                RaceEntryId = raceEntry.Id,
                DriverId = driverId,
            });

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Success();
        }
    }
}
