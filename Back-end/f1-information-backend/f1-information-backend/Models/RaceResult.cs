using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace f1_information_backend.Models
{
    public class RaceResult
    {
        public int RaceId { get; set; }
        public int ResultId { get; set; }
        public Race Race { get; set; }
        public Result Result { get; set; }
    }
}
