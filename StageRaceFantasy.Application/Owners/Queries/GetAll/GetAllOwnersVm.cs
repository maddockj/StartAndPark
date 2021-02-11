using StageRaceFantasy.Application.Common.AutoMapper;
using StageRaceFantasy.Domain.Entities;
using System.Collections.Generic;

namespace StageRaceFantasy.Application.FantasyTeams.Queries.GetAll
{
    public class GetAllOwnersVm
    {
        public List<OwnerDto> Owners { get; set; }
    }

    public class OwnerDto : IMapFrom<Owner>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
