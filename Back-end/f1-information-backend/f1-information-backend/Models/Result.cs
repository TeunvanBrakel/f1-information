using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace f1_information_backend.Models
{
    public class Result
    {
        public int Result_id { get; set; }
        private int driverFinished;
        private int points;

        public Result(int _driverFinished, int _points)
        {
            driverFinished = _driverFinished;
            points = _points;
        }
    }
}
