using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StartAndPark.Domain.Entities
{
    public class RaceEntry
    {
        [Key]
        public int Id { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
        public int RaceId { get; set; }
        public Race Race { get; set; }
        public string CarNumber { get; set; }
        public string Tier { get; set; }
        [JsonIgnore]
        public List<RacePick> RacePicks { get; set; }
    }
}
