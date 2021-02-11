using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using StageRaceFantasy.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.RiderRaceEntries.Commands.Create
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

            var raceEntryExists = await _dbContext.DriverRaceEntries
                .AnyAsync(x => x.RaceId == raceId && x.DriverId == driverId, cancellationToken);

            if (raceEntryExists) return BadRequest();

            var raceExists = await _dbContext.Races.AnyAsync(x => x.Id == raceId, cancellationToken);
            var driverExists = await _dbContext.Drivers.AnyAsync(x => x.Id == driverId, cancellationToken);

            if (!raceExists || !driverExists) return NotFound();

            var driverRaceEntry = new DriverRaceEntry()
            {
                RaceId = raceId,
                DriverId = driverId,
            };

            await _dbContext.DriverRaceEntries.AddAsync(driverRaceEntry, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Success();
        }
    }
}
