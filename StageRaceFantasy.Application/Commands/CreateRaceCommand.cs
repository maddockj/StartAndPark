using StartAndPark.Application.Common.Interfaces;
using StartAndPark.Application.Common.Requests;
using StartAndPark.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StartAndPark.Application
{
    public record CreateRaceCommand : IApplicationCommand<int>
    {
        public string Name { get; init; }
        public int NascarId { get; init; }
        public int Type { get; init; }
        public int TrackId { get; init; }
        public DateTime? StartTime { get; init; }
        public int? WinningDriverId { get; init; }
    }

    public class CreateRaceCommandHandler : ApplicationRequestHandler<CreateRaceCommand, int>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateRaceCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<ApplicationRequestResult<int>> Handle(CreateRaceCommand request, CancellationToken cancellationToken)
        {
            var race = new Race()
            {
                Name = request.Name,
                NascarId = request.NascarId,
                Type = request.Type,
                TrackId = request.TrackId,
                StartTime = request.StartTime,
                WinningDriverId = request.WinningDriverId
            };

            _dbContext.Races.Add(race);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Success(race.Id);
        }
    }
}
