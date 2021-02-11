using StartAndPark.Application.Common.AutoMapper;
using StartAndPark.Domain.Entities;
using System.Collections.Generic;

namespace StartAndPark.Application.RaceEntries.Queries.GetById
{
    public class GetRaceEntryByIdVm : IMapFrom<RaceEntry>
    {
        public int OwnerId { get; set; }
        public int RaceId { get; set; }
        public string RaceName { get; set; }
        public int TeamSize { get; set; }
        public List<DriverDto> Drivers { get; set; }
    }

    public class DriverDto : IMapFrom<Driver>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
