using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace f1_information_backend.Models
{
    public class Season
    {
        public int Season_id { get; set; }
        private int year;
        private int numberOfRaces;
        private string[] driverStandings;
        private string[] constructorStandings;

        public Season(int _year, int _numberOfRaces, string[] _driverStandings, string[] _constructorStandings)
        {
            year = _year;
            numberOfRaces = _numberOfRaces;
            driverStandings = _driverStandings;
            constructorStandings = _constructorStandings;
        }
    }
}
