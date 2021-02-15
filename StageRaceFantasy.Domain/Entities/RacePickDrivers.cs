namespace StartAndPark.Domain.Entities
{
    public class RacePickDrivers
    {
        public int RacePickId { get; set; }
        public RacePick RacePick { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
    }
}
