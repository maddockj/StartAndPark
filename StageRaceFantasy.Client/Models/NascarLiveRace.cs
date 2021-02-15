using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartAndPark.Client.Models
{
    public class NascarLiveRace
    {
        public int race_id { get; set; }
        public int lap_number { get; set; }
        public int flag_state { get; set; }
        public int laps_in_race { get; set; }
        public int laps_to_go { get; set; }
        public NascarLiveVehicle[] vehicles { get; set; }
        public int run_id { get; set; }
        public string run_name { get; set; }
        public int track_id { get; set; }
        public int run_type { get; set; }
        public int number_of_caution_segments { get; set; }
        public int number_of_caution_laps { get; set; }
        public int number_of_lead_changes { get; set; }
        public int number_of_leaders { get; set; }
        public NascarLiveStage stage { get; set; }
    }

    public class NascarLiveVehicle
    {
        public string vehicle_manufacturer { get; set; }
        public string vehicle_number { get; set; }
        public NascarLiveDriver driver { get; set; }
        public int laps_completed { get; set; }
        public NascarLiveLapsLed[] laps_led { get; set; }
        public int qualifying_status { get; set; }
        public int running_position { get; set; }
        public bool is_on_track { get; set; }
        public bool is_on_dvp { get; set; }

    }

    public class NascarLiveDriver
    {
        public int driver_id { get; set; }
        public string full_name { get; set; }
        public bool is_in_chase { get; set; }
    }

    public class NascarLiveLapsLed
    {
        public int start_lap { get; set; }
        public int end_lap { get; set; }
    }

    public class NascarLiveStage
    {
        public int stage_num { get; set; }
        public int finish_at_lap { get; set; }
        public int laps_in_stage { get; set; }
    }
}
