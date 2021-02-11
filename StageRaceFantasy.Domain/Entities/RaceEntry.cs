using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StageRaceFantasy.Domain.Entities
{
    public class RaceEntry
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public Owner FantasyTeam { get; set; }
        public int RaceId { get; set; }
        public Race Race { get; set; }
        public List<RaceEntryDriver> RaceEntryDrivers { get; set; }

        [NotMapped]
        public List<Driver> Drivers => RaceEntryDrivers.Select(x => x.Driver).ToList();

        public RaceEntry()
        {
            RaceEntryDrivers = new List<RaceEntryDriver>();
        }
    }
}
