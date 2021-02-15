using MediatR;
using StartAndPark.Application.Common.Interfaces;
using StartAndPark.Application.Common.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace StartAndPark.Application
{
    public record UpdateDriverRaceEntryCommand(int RaceId, int DriverId, string CarNumber, string Tier)
        : IRequest<ApplicationRequestResult>
    {
    }

    public class UpdateDriverRaceEntryHandler : ApplicationRequestHandler<UpdateDriverRaceEntryCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateDriverRaceEntryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<ApplicationRequestResult> Handle(UpdateDriverRaceEntryCommand request, CancellationToken cancellationToken)
        {
            var raceId = request.RaceId;
            var driverId = request.DriverId;

            var driverRaceEntry = await _dbContext.RaceEntries
                .FindAsync(new object[] { raceId, driverId }, cancellationToken: cancellationToken);

            if (driverRaceEntry == null) return NotFound();

            driverRaceEntry.CarNumber = request.CarNumber;
            driverRaceEntry.Tier = request.Tier;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Success();
        }
    }
}
