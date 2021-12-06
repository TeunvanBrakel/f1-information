using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace f1_information_backend.Models
{
    public class RaceDrivers
    {
        public int RaceId { get; set; }
        public int DriverId { get; set; }
        public Race Race { get; set; }
        public Driver Driver { get; set; }

        public RaceDrivers()
        {

        }
    }
}
