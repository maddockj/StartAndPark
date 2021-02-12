using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using StartAndPark.Application.Common.Interfaces;
using StartAndPark.Application.Common.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace StartAndPark.Application
{
    public class GetAllRacesQuery : IApplicationQuery<GetAllRacesVm>
    {
    }

    public class GetAllRacesHandler : ApplicationRequestHandler<GetAllRacesQuery, GetAllRacesVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllRacesHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override async Task<ApplicationRequestResult<GetAllRacesVm>> Handle(GetAllRacesQuery request, CancellationToken cancellationToken)
        {
            var raceDtos = await _dbContext.Races.Include(x => x.Track)
                .ProjectTo<RaceDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return Success(new GetAllRacesVm()
            {
                ItemList = raceDtos,
            });
        }
    }
}
