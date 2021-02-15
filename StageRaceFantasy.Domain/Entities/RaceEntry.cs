namespace StartAndPark.Domain.Entities
{
    public class RaceEntry
    {
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
        public int RaceId { get; set; }
        public Race Race { get; set; }
        public string CarNumber { get; set; }
        public string Tier { get; set; }
    }
}
