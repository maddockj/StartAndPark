using MediatR;
using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.RiderRaceEntries.Commands.Update
{
    public record UpdateDriverRaceEntryCommand(int RaceId, int DriverId, string CarNumber)
        : IRequest<ApplicationRequestResult>
    {
    }

    public class UpdateRiderRaceEntryHandler : ApplicationRequestHandler<UpdateDriverRaceEntryCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateRiderRaceEntryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<ApplicationRequestResult> Handle(UpdateDriverRaceEntryCommand request, CancellationToken cancellationToken)
        {
            var raceId = request.RaceId;
            var riderId = request.DriverId;

            var riderRaceEntry = await _dbContext.DriverRaceEntries
                .FindAsync(new object[] { raceId, riderId }, cancellationToken: cancellationToken);

            if (riderRaceEntry == null) return NotFound();

            riderRaceEntry.CarNumber = request.CarNumber;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Success();
        }
    }
}
