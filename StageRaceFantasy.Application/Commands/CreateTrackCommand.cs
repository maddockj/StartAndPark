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
        public int NascarId { get; set; }
        public string Surface { get; set; }
        public string Type { get; set; }
        public decimal Length { get; set; }
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
                NascarId = request.NascarId,
                Surface = request.Surface,
                Type = request.Type,
                Length = request.Length
            };

            _dbContext.Tracks.Add(track);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Success(track.Id);
        }
    }
}
