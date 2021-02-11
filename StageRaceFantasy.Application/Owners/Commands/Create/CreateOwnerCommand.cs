using StartAndPark.Application.Common.Interfaces;
using StartAndPark.Application.Common.Requests;
using StartAndPark.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace StartAndPark.Application.Owners.Commands.Create
{
    public record CreateOwnerCommand(string Name) : IApplicationCommand<Owner>
    {
    }

    public class CreateOwnerHandler : ApplicationRequestHandler<CreateOwnerCommand, Owner>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateOwnerHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<ApplicationRequestResult<Owner>> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
        {
            var owner = new Owner()
            {
                Name = request.Name,
            };

            _dbContext.Owners.Add(owner);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Success(owner);
        }
    }
}
