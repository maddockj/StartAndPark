using StartAndPark.Application.Common.AutoMapper;
using System.Collections.Generic;

namespace StartAndPark.Domain.Entities
{
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
