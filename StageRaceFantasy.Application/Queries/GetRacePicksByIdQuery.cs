using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StartAndPark.Application.Common.Interfaces;
using StartAndPark.Application.Common.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace StartAndPark.Application
{
    public record GetRacePicksByIdQuery(int OwnerId, int RaceId)
        : IApplicationQuery<GetRacePickByIdVm>
    {
    }

    public class GetRacePickByIdHandler : ApplicationRequestHandler<GetRacePicksByIdQuery, GetRacePickByIdVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetRacePickByIdHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override async Task<ApplicationRequestResult<GetRacePickByIdVm>> Handle(GetRacePicksByIdQuery request,
                                                                                                   CancellationToken cancellationToken)
        {
            var ownerId = request.OwnerId;
            var raceId = request.RaceId;

            var entry = await _dbContext.RacePicks
                .Include(x => x.RaceEntries)
                    .ThenInclude(x => x.Driver)
                .Include(x => x.Race)
                .FirstOrDefaultAsync(
                    x => x.OwnerId == ownerId && x.RaceId == raceId,
                    cancellationToken);

            if (entry == null) return NotFound();

            var result = _mapper.Map<GetRacePickByIdVm>(entry);

            var race = await _dbContext.Races.FindAsync(new object[]{ raceId }, cancellationToken);

            return new(result);
        }
    }
}
