using StartAndPark.Application.Common.Interfaces;
using StartAndPark.Application.Common.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace StartAndPark.Application
{ 
    public record DeleteOwnerCommand(int Id) : IApplicationCommand
    {
    }

    public class DeleteOwnerHandler : ApplicationRequestHandler<DeleteOwnerCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteOwnerHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<ApplicationRequestResult> Handle(DeleteOwnerCommand request, CancellationToken cancellationToken)
        {
            var id = new object[] { request.Id };

            var owner = await _dbContext.Owners.FindAsync(id, cancellationToken);

            if (owner == null) return NotFound();

            _dbContext.Owners.Remove(owner);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Success();
        }
    }
}
