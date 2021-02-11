using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartAndPark.Domain.Entities
{
    public class Driver
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [NotMapped]
        public string DisplayNameLastFirst => $"{LastName}, {FirstName}";

        public List<RaceEntryDriver> RaceEntryDrivers { get; set; }
    }
}
