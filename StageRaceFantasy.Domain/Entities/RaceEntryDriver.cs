namespace StageRaceFantasy.Domain.Entities
{
    public class RaceEntryDriver
    {
        public int RaceEntryId { get; set; }
        public RaceEntry RaceEntry { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
    }
}
