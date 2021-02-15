using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using StartAndPark.Application.Common.Interfaces;
using StartAndPark.Application.Common.Requests;
using StartAndPark.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StartAndPark.Application
{
    public record GetAllRacePicksQuery(int TeamId)
        : IApplicationQuery<GetAllRacePicksVm>
    {
    }
    public class GetAllRacePicksHandler : ApplicationRequestHandler<GetAllRacePicksQuery, GetAllRacePicksVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllRacePicksHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override async Task<ApplicationRequestResult<GetAllRacePicksVm>> Handle(
            GetAllRacePicksQuery request,
            CancellationToken cancellationToken)
        {
            var ownerId = request.TeamId;

            var ownerExists = await _dbContext.Owners.AnyAsync(x => x.Id == ownerId, cancellationToken: cancellationToken);

            if (!ownerExists) return NotFound();

            var racePicks = await _dbContext.RacePicks
                .Where(x => x.OwnerId == ownerId)
                .OrderBy(x => x.Race.Name)
                .ProjectTo<RacePickDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);

            return Success(new GetAllRacePicksVm()
            {
                Picks = racePicks,
            });
        }
    }
}
