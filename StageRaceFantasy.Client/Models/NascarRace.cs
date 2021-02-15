using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartAndPark.Client.Models
{
    public class NascarRace
    {
        public int race_type_id { get; set; }
        public int race_id { get; set; }
        public int series_id { get; set; }
        public int race_season { get; set; }
        public string race_name { get; set; }
        public int track_id { get; set; }
        public string track_name { get; set; }
        public DateTime date_scheduled { get; set; }
        public DateTime race_date { get; set; }
        public DateTime qualifying_date { get; set; }
        public decimal scheduled_distance { get; set; }
        public int scheduled_laps { get; set; }
        public int actual_laps { get; set; }
        public object winner_driver_id { get; set; }

        public bool IsComplete => int.TryParse(winner_driver_id?.ToString(), out _);

        public int? WinningDriverId => IsComplete ? int.Parse(winner_driver_id.ToString()) : null;
    }
}
