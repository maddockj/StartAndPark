using StageRaceFantasy.Application.Common.AutoMapper;
using StageRaceFantasy.Domain.Entities;

namespace StageRaceFantasy.Application.RiderRaceEntries.Commands.Create
{
    public class CreateDriverRaceEntryDto : IMapFrom<DriverRaceEntry>
    {
        public int RaceId { get; set; }
        public int DriverId { get; set; }
    }
}
