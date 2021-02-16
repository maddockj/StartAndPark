using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartAndPark.Client.Models
{
    public class NascarWeekend
    {
        public NascarWeekendRace[] weekend_race { get; set; }
        public NascarWeekendRun[] weekend_runs { get; set; }
    }

    public class NascarWeekendRace
    {
        public int race_id { get; set; }
        public int series_id { get; set; }
        public int race_season { get; set; }
        public string race_name { get; set; }
        public int race_type_id { get; set; }
        public bool restrictor_plate { get; set; }
        public int track_id { get; set; }
        public string track_name { get; set; }
        public DateTime? date_scheduled { get; set; }
        public DateTime? race_date { get; set; }
        public DateTime? qualifying_date { get; set; }
        public int scheduled_distance { get; set; }
        public int actual_distance { get; set; }
        public int scheduled_laps { get; set; }
        public int actual_laps { get; set; }
        public int stage_1_laps { get; set; }
        public int stage_2_laps { get; set; }
        public int stage_3_laps { get; set; }
        public int stage_4_laps { get; set; }
        public int pole_winner_driver_id { get; set; }
        public string race_comments { get; set; }
        public NascarRaceResult[] results { get; set; }
        public NascarStage[] stage_results { get; set; }
        public string television_broadcaster { get; set; }
        public int playoff_round { get; set; }
    }

    public class NascarWeekendRun
    {
        public int run_type { get; set; }
        public string run_name { get; set; }
        public DateTime? run_date_utc { get; set; }
    }

    public class NascarRaceResult
    {
        public int finishing_position { get; set; }
        public int starting_position { get; set; }
        public string car_number { get; set; }
        public string driver_fullname { get; set; }
        public int driver_id { get; set; }
        public int laps_led { get; set; }
        public string car_make { get; set; }
        public int points_earned { get; set; }
        public int playoff_points_earned { get; set; }
        public int laps_completed { get; set; }
        public string finishing_status { get; set; }
    }

    public class NascarStage
    {
        public int stage_number { get; set; }
        public NascarStageResult[] results { get; set; }
    }

    public class NascarStageResult : NascarRaceResult
    {
        public int stage_points { get; set; }
    }

    public class NascarRunResult
    {
        public string car_number { get; set; }
        public string manufacturer { get; set; }
        public int driver_id { get; set; }
        public string driver_name { get; set; }
        public int finishing_position { get; set; }
    }
}
