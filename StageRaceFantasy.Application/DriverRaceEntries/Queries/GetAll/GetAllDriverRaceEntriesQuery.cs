using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using StartAndPark.Application.Common.Interfaces;
using StartAndPark.Application.Common.Requests;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StartAndPark.Application.DriverRaceEntries.Queries.GetAll
{
    public record GetAllDriverRaceEntriesQuery(int RaceId) : IApplicationQuery<GetAllDriverRaceEntriesVm>
    {
    }

    public class GetAllDriverRaceEntriesHandler : ApplicationRequestHandler<GetAllDriverRaceEntriesQuery, GetAllDriverRaceEntriesVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllDriverRaceEntriesHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override async Task<ApplicationRequestResult<GetAllDriverRaceEntriesVm>> Handle(
            GetAllDriverRaceEntriesQuery request,
            CancellationToken cancellationToken)
        {
            var raceId = request.RaceId;

            var raceExists = await _dbContext.Races.AnyAsync(x => x.Id == raceId, cancellationToken);

            if (!raceExists) return NotFound();

            var driverRaceEntries = await _dbContext.DriverRaceEntries
                .AsNoTracking()
                .Include(x => x.Race)
                .Include(x => x.Driver)
                .Where(x => x.RaceId == raceId)
                .OrderBy(x => x.Driver.LastName)
                .ProjectTo<DriverRaceEntryDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var enteredDriverIds = driverRaceEntries.Select(x => x.DriverId);

            var notEnteredDrivers = await _dbContext.Drivers
                .Where(x => !enteredDriverIds.Contains(x.Id))
                .OrderBy(x => x.LastName)
                .ProjectTo<DriverRaceEntryDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);


            driverRaceEntries.ForEach(x => x.IsEntered = true);
            notEnteredDrivers.ForEach(x => x.RaceId = raceId);

            return Success(new GetAllDriverRaceEntriesVm()
            {
                Entries = driverRaceEntries
                    .Concat(notEnteredDrivers)
                    .ToList(),
            });
        }
    }
}
