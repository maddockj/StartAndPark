using StartAndPark.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartAndPark.Client.Models
{
    public class PointsCalculator
    {
        public static Dictionary<int, CalculatedDriver> CalculatePoints(NascarWeekendRace race)
        {
            var drivers = new Dictionary<int, CalculatedDriver>();
            
            foreach (var r in race.results)
            {
                var did = r.driver_id;
                if (!drivers.ContainsKey(did))
                {
                    drivers.Add(did, new CalculatedDriver(r));
                }

                drivers[did].Points += GetPositionPoints(r.finishing_position);
            }

            foreach (var stage in race.stage_results)
            {
                foreach (var r in stage.results)
                {
                    var did = r.driver_id;
                    if (!drivers.ContainsKey(did))
                    {
                        drivers.Add(did, new CalculatedDriver(r));
                    }

                    drivers[did].Points += GetStagePoints(r.finishing_position);
                }
            }

            return drivers;
        }

        public static void UpdateEventPoints(List<RacePickResultDto> results)
        {
            if (results == null) return;

            int i = 1;
            foreach (var r in results.OrderByDescending(x => x.Points))
            {
                r.Rank = i;
                r.EventPoints = GetEventPoints(i++);
            }
        }

        public static decimal GetPositionPoints(int position)
        {
            return position switch
            {
                1 => 40,
                2 => 35,
                _ => Math.Max(1, 37 - position)
            };
        }

        public static decimal GetStagePoints(int position)
        {
            return 11 - position;
        }

        public static int GetEventPoints(int position)
        {
            if (position < 4)
            {
                return 55 - (position * 5);
            }
            else if (position < 14)
            {
                return 46 - (position * 2);
            }
            else
            {
                return Math.Max(1, 33 - position);
            }
        }
    }

    public class CalculatedDriver
    {
        public int NascarDriverId { get; set; }
        public string CarNumber { get; set; }
        public string DriverName { get; set; }
        public decimal Points { get; set; }

        public CalculatedDriver(NascarRaceResult r)
        {
            NascarDriverId = r.driver_id;
            CarNumber = r.car_number;
            DriverName = r.driver_fullname;
        }
    }
}
