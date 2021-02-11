using StageRaceFantasy.Application.Common.AutoMapper;
using StageRaceFantasy.Domain.Entities;
using System.Collections.Generic;

namespace StageRaceFantasy.Application.FantasyTeamRaceEntries.Queries.GetById
{
    public class GetRaceEntryByIdVm : IMapFrom<RaceEntry>
    {
        public int OwnerId { get; set; }
        public int RaceId { get; set; }
        public string RaceName { get; set; }
        public int FantasyTeamSize { get; set; }
        public List<DriverDto> Drivers { get; set; }
    }

    public class DriverDto : IMapFrom<Driver>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
