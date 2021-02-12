using StartAndPark.Application.Common.AutoMapper;
using StartAndPark.Application.Common.Interfaces;
using StartAndPark.Domain.Entities;
using System.Collections.Generic;

namespace StartAndPark.Application
{
    public record GetOwnerByIdVm : IMapFrom<Owner>
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public List<RaceEntryDto> RaceEntries { get; init; }
    }

    public class GetAllOwnersVm : IListVm<OwnerDto>
    {
        public List<OwnerDto> ItemList { get; set; }
    }

    public record OwnerDto : IMapFrom<Owner>
    {
        public int Id { get; init; }
        public string Name { get; init; }
    }
}
