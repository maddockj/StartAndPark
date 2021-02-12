using StartAndPark.Application.Common.Interfaces;
using StartAndPark.Application.Common.Requests;
using StartAndPark.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace StartAndPark.Application
{
    public record CreateTrackCommand : IApplicationCommand<int>
    {
        public string Name { get; init; }
    }

    public class CreateTrackCommandHandler : ApplicationRequestHandler<CreateTrackCommand, int>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateTrackCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<ApplicationRequestResult<int>> Handle(CreateTrackCommand request, CancellationToken cancellationToken)
        {
            var track = new Track()
            {
                Name = request.Name,
            };

            _dbContext.Tracks.Add(track);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Success(track.Id);
        }
    }
}
