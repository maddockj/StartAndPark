using StartAndPark.Application.Common.AutoMapper;
using StartAndPark.Domain.Entities;
using System.Collections.Generic;

namespace StartAndPark.Application.Owners.Queries.GetById
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
