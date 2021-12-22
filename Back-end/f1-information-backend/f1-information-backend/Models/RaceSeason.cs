using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace f1_information_backend.Models
{
    public class RaceSeason
    {
        public int SeasonId { get; set; }
        public int RaceId { get; set; }
        public Season Season { get; set; }
        public Race Race { get; set; }

        public RaceSeason()
        {

        }
    }
}
