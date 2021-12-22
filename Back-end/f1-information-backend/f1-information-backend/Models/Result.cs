using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace f1_information_backend.Models
{
    public class Result
    {
        public int Id { get; set; }
        public int DriverFinished { get; private set; }
        public int Points { get; private set; }

        public ICollection<RaceResult> Races { get; set; }
        public ICollection<DriverResult> Drivers { get; set; }

        public Result(int _driverFinished, int _points)
        {
            DriverFinished = _driverFinished;
            Points = _points;
        }
        public Result()
        {

        }
    }
}
