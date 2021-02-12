using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using StartAndPark.Application.Common.Interfaces;
using StartAndPark.Application.Common.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace StartAndPark.Application
{
    public class GetAllOwnersQuery : IApplicationQuery<GetAllOwnersVm>
    {
    }

    public class GetAllOwnersHandler : ApplicationRequestHandler<GetAllOwnersQuery, GetAllOwnersVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllOwnersHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override async Task<ApplicationRequestResult<GetAllOwnersVm>> Handle(GetAllOwnersQuery request, CancellationToken cancellationToken)
        {
            var ownerDtos = await _dbContext.Owners
                .ProjectTo<OwnerDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return Success(new GetAllOwnersVm()
            {
                ItemList = ownerDtos,
            });
        }
    }
}
