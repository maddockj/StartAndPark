using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartAndPark.Domain.Entities
{
    public class Track
    {
        public int Id { get; set; }

        [Required]
        public int NascarId { get; set; }

        [Required] 
        public string Name { get; set; }

        public string Surface { get; set; }

        public string Type { get; set; }

        [Column(TypeName ="decimal(18,3)")]
        public decimal Length { get; set; }

        public List<Race> Races { get; set; }

        public Track()
        {
            Races = new List<Race>();
        }
    }
}
