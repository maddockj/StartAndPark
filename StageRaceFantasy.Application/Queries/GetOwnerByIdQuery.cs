using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StartAndPark.Application.Common.Interfaces;
using StartAndPark.Application.Common.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace StartAndPark.Application
{
    public record GetOwnerByIdQuery(int OwnerId) : IApplicationQuery<GetOwnerByIdVm>
    {
    }

    public class GetOwnerByIdHandler : IApplicationQueryHandler<GetOwnerByIdQuery, GetOwnerByIdVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOwnerByIdHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ApplicationRequestResult<GetOwnerByIdVm>> Handle(GetOwnerByIdQuery request, CancellationToken cancellationToken)
        {
            var ownerId = request.OwnerId;

            var owner = await _dbContext.Owners
                .Include(x => x.RaceEntries)
                    .ThenInclude(x => x.Race)
                .FirstOrDefaultAsync(x => x.Id == ownerId, cancellationToken);

            if (owner == null)
            {
                return new()
                {
                    IsNotFound = true,
                };
            }

            return new(_mapper.Map<GetOwnerByIdVm>(owner));
        }
    }
}
