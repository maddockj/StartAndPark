using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StartAndPark.Domain.Entities
{
    public class RacePick
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
        public int RaceId { get; set; }
        public Race Race { get; set; }
        public List<RaceEntry> RaceEntries { get; set; }

        public RacePick()
        {
            RaceEntries = new List<RaceEntry>();
        }
    }
}
