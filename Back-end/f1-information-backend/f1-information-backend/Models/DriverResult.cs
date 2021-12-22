using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace f1_information_backend.Models
{
    public class DriverResult
    {
        public int DriverId { get; set; }
        public int ResultId { get; set; }
        public Driver Driver { get; set; }
        public Result Result { get; set; }
    }
}
