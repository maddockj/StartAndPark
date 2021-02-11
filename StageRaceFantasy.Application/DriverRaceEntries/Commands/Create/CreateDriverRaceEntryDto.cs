using StartAndPark.Application.Common.AutoMapper;
using StartAndPark.Domain.Entities;

namespace StartAndPark.Application.DriverRaceEntries.Commands.Create
{
    public class CreateDriverRaceEntryDto : IMapFrom<DriverRaceEntry>
    {
        public int RaceId { get; set; }
        public int DriverId { get; set; }
    }
}
