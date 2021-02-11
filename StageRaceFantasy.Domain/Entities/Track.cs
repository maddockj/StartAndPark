using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartAndPark.Domain.Entities
{
    public class Track
    {
        public int Id { get; set; }

        [Required] 
        public string Name { get; set; }

        public List<Race> Races { get; set; }

        public Track()
        {
            Races = new List<Race>();
        }
    }
}
