using System.Collections.Generic;

namespace StartAndPark.Domain.Entities
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<RaceEntry> RaceEntries { get; set; }
    }
}
