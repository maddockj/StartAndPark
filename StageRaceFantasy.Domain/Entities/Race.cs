using System.Collections.Generic;

namespace StartAndPark.Domain.Entities
{
    public class Race
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeamSize { get; set; }
        public List<DriverRaceEntry> DriverEntries { get; set; }

        public Race()
        {
            DriverEntries = new List<DriverRaceEntry>();
        }
    }
}
