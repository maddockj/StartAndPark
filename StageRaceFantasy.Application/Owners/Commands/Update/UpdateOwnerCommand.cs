using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.FantasyTeams.Commands.Update
{
    public record UpdateOwnerCommand(int Id, string Name) : IApplicationCommand
    {
    }

    public class UpdateOwnerHandler : ApplicationRequestHandler<UpdateOwnerCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateOwnerHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<ApplicationRequestResult> Handle(UpdateOwnerCommand request, CancellationToken cancellationToken)
        {
            var id = request.Id;
            var newName = request.Name;

            var owner = await _dbContext.Owners.FindAsync(new object[] { id }, cancellationToken: cancellationToken);

            if (owner == null) return NotFound();

            owner.Name = newName;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Success();
        }
    }
}
