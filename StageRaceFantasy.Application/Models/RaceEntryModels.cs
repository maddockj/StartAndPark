using StartAndPark.Application.Common.AutoMapper;
using StartAndPark.Domain.Entities;
using System.Collections.Generic;

namespace StartAndPark.Application
{
    public class GetRacePickByIdVm : IMapFrom<RacePick>
    {
        public int OwnerId { get; set; }
        public int RaceId { get; set; }
        public string RaceName { get; set; }
        public int TeamSize { get; set; }
        public List<DriverDto> Drivers { get; set; }
    }

    public class GetAllRacePicksVm
    {
        public List<RacePickDto> Picks { get; set; }
    }

    public class RacePickDto : IMapFrom<RacePick>
    {
        public int OwnerId { get; set; }
        public int RaceId { get; set; }
        public int RaceName { get; set; }
    }    
}
