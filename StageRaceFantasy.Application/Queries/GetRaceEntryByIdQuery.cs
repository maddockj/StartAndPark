using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StartAndPark.Application.Common.Interfaces;
using StartAndPark.Application.Common.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace StartAndPark.Application
{
    public record GetRaceEntryByIdQuery(int OwnerId, int RaceId)
        : IApplicationQuery<GetRaceEntryByIdVm>
    {
    }

    public class GetaceEntryByIdHandler : ApplicationRequestHandler<GetRaceEntryByIdQuery, GetRaceEntryByIdVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetaceEntryByIdHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override async Task<ApplicationRequestResult<GetRaceEntryByIdVm>> Handle(GetRaceEntryByIdQuery request,
                                                                                                   CancellationToken cancellationToken)
        {
            var ownerId = request.OwnerId;
            var raceId = request.RaceId;

            var entry = await _dbContext.RaceEntries
                .Include(x => x.RaceEntryDrivers)
                    .ThenInclude(x => x.Driver)
                .Include(x => x.Race)
                .FirstOrDefaultAsync(
                    x => x.OwnerId == ownerId && x.RaceId == raceId,
                    cancellationToken);

            if (entry == null) return NotFound();

            var result = _mapper.Map<GetRaceEntryByIdVm>(entry);

            var race = await _dbContext.Races.FindAsync(new object[]{ raceId }, cancellationToken);
            result.TeamSize = race.TeamSize;

            return new(result);
        }
    }
}
