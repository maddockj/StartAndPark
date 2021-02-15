using Microsoft.EntityFrameworkCore;
using StartAndPark.Application.Common.Interfaces;
using StartAndPark.Application.Common.Requests;
using StartAndPark.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace StartAndPark.Application
{
    public class CreateDriverRaceEntryCommand :
        CreateDriverRaceEntryDto,
        IApplicationCommand
    {
    }

    public class CreateDriverRaceEntryHandler : ApplicationRequestHandler<CreateDriverRaceEntryCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateDriverRaceEntryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<ApplicationRequestResult> Handle(
            CreateDriverRaceEntryCommand request,
            CancellationToken cancellationToken)
        {
            var raceId = request.RaceId;
            var driverId = request.DriverId;
            var carNum = request.CarNumber;
            var tier = request.Tier;

            var raceEntryExists = await _dbContext.RaceEntries
                .AnyAsync(x => x.RaceId == raceId && x.DriverId == driverId, cancellationToken);

            if (raceEntryExists) return BadRequest();

            var raceExists = await _dbContext.Races.AnyAsync(x => x.Id == raceId, cancellationToken);
            var driverExists = await _dbContext.Drivers.AnyAsync(x => x.Id == driverId, cancellationToken);

            if (!raceExists || !driverExists) return NotFound();

            var driverRaceEntry = new RaceEntry()
            {
                RaceId = raceId,
                DriverId = driverId,
                CarNumber = carNum,
                Tier = tier
            };

            await _dbContext.RaceEntries.AddAsync(driverRaceEntry, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Success();
        }
    }
}
