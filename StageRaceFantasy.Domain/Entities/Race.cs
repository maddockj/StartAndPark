using System.Collections.Generic;

namespace StageRaceFantasy.Domain.Entities
{
    public class Race
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FantasyTeamSize { get; set; }
        public List<DriverRaceEntry> DriverEntries { get; set; }

        public Race()
        {
            DriverEntries = new List<DriverRaceEntry>();
        }
    }
}
