using StageRaceFantasy.Application.Common.AutoMapper;
using StageRaceFantasy.Domain.Entities;
using System.Collections.Generic;

namespace StageRaceFantasy.Application.FantasyTeams.Queries.GetById
{
    public record GetOwnerByIdVm : IMapFrom<Owner>
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public List<RaceEntryDto> RaceEntries { get; init; }
    }

    public record RaceEntryDto : IMapFrom<RaceEntry>
    {
        public int RaceId { get; init; }
        public string RaceName { get; init; }
    }
}
