using StartAndPark.Application.Common.Interfaces;
using StartAndPark.Application.Common.Requests;
using StartAndPark.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace StartAndPark.Application
{
    public record CreateRaceCommand : IApplicationCommand<int>
    {
        public string Name { get; init; }
        public int RaceId { get; init; }
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
                Id = request.RaceId
            };

            _dbContext.Races.Add(race);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Success(race.Id);
        }
    }
}
