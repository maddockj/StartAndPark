using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StartAndPark.Domain.Entities
{
    public class Race
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int TeamSize { get; set; }

        [Required]
        public int TrackId { get; set; }
        public Track Track { get; set; }

        public List<DriverRaceEntry> DriverEntries { get; set; }

        public Race()
        {
            DriverEntries = new List<DriverRaceEntry>();
        }
    }
}
