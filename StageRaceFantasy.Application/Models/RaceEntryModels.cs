using StartAndPark.Application.Common.AutoMapper;
using StartAndPark.Domain.Entities;
using System.Collections.Generic;

namespace StartAndPark.Application
{
    public class GetRaceEntryByIdVm : IMapFrom<RaceEntry>
    {
        public int OwnerId { get; set; }
        public int RaceId { get; set; }
        public string RaceName { get; set; }
        public int TeamSize { get; set; }
        public List<DriverDto> Drivers { get; set; }
    }

    public class GetAllRaceEntriesVm
    {
        public List<RaceEntryDto> Entries { get; set; }
    }

    public class RaceEntryDto : IMapFrom<RaceEntry>
    {
        public int OwnerId { get; set; }
        public int RaceId { get; set; }
        public int RaceName { get; set; }
    }    
}
