using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using StageRaceFantasy.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.FantasyTeamRaceEntries.Queries.GetAll
{
    public record GetAllRaceEntriesQuery(int TeamId)
        : IApplicationQuery<GetAllRaceEntriesVm>
    {
    }
    public class GetAllRaceEntriesHandler : ApplicationRequestHandler<GetAllRaceEntriesQuery, GetAllRaceEntriesVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllRaceEntriesHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override async Task<ApplicationRequestResult<GetAllRaceEntriesVm>> Handle(
            GetAllRaceEntriesQuery request,
            CancellationToken cancellationToken)
        {
            var ownerId = request.TeamId;

            var ownerExists = await _dbContext.Owners.AnyAsync(x => x.Id == ownerId, cancellationToken: cancellationToken);

            if (!ownerExists) return NotFound();

            var entries = await _dbContext.RaceEntries
                .Where(x => x.OwnerId == ownerId)
                .OrderBy(x => x.Race.Name)
                .ProjectTo<RaceEntryDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);

            return Success(new GetAllRaceEntriesVm()
            {
                Entries = entries,
            });
        }
    }
}
