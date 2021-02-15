using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartAndPark.Client.Models
{
    public class NascarDriver
    {
        public string vehicle_number { get; set; }
        public int driver_id { get; set; }
        public string driver_name { get; set; }
        public string PicksTier { get; set; }
    }
}
