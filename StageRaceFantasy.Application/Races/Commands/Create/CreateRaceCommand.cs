using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using StageRaceFantasy.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.Races.Commands.Create
{
    public record CreateRaceCommand : IApplicationCommand<int>
    {
        public string Name { get; init; }
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
            };

            _dbContext.Races.Add(race);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Success(race.Id);
        }
    }
}
