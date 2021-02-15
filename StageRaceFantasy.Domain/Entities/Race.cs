using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StartAndPark.Domain.Entities
{
    public class Race
    {
        public const int RACE_TYPE_NON_POINTS = 1;
        public const int RACE_TYPE_POINTS = 2;

        public int Id { get; set; }

        [Required]
        public int NascarId { get; set; }

        [Required]
        public string Name { get; set; }

        public int Type { get; set; }

        [Required]
        public int TrackId { get; set; }
        public Track Track { get; set; }

        public DateTime? StartTime { get; set; }

        public int? WinningDriverId { get; set; }
        public Driver WinningDriver { get; set; }

        public bool IsComplete => WinningDriverId.HasValue;

        public List<DriverRaceEntry> DriverEntries { get; set; }

        public Race()
        {
            DriverEntries = new List<DriverRaceEntry>();
        }
    }
}
