using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StartAndPark.Domain.Entities
{
    public class Driver
    {
        public int Id { get; set; }

        [Required]
        public int NascarId {get; set; }

        [Required]
        public string Name { get; set; }
    }
}
