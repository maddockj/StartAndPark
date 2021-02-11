﻿using StartAndPark.Application.Common.Interfaces;
using StartAndPark.Application.Common.Requests;
using StartAndPark.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace StartAndPark.Application.Races.Commands.Create
{
    public record CreateTrackCommand : IApplicationCommand<int>
    {
        public string Name { get; init; }
        public int TrackId { get; init; }
    }

    public class CreateTrackCommandHandler : ApplicationRequestHandler<CreateTrackCommand, int>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateTrackCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<ApplicationRequestResult<int>> Handle(CreateTrackCommand request, CancellationToken cancellationToken)
        {
            var race = new Race()
            {
                Name = request.Name,
                TrackId = request.TrackId
            };

            _dbContext.Races.Add(race);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Success(race.Id);
        }
    }
}
