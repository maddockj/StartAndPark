using StartAndPark.Application.Common.AutoMapper;
using StartAndPark.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

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

    public class RacePickResultDto
    {
        public string OwnerName { get; set; }
        public List<Pick> Picks { get; set; } = new List<Pick>();
        public decimal Points => Picks?.Sum(x => x?.Points) ?? 0m;
        public int EventPoints { get; set; }
        public int Rank { get; set; }

        public class Pick
        {
            public int DriverNascarId { get; set; }
            public string DriverName { get; set; }
            public string CarNumber { get; set; }
            public decimal Points { get; set; }
        }
    }
}
