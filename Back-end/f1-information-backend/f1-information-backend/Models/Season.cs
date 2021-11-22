using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace f1_information_backend.Models
{
    public class Season
    {
        public int Id { get; set; }
        public int Year { get; private set; }
        public int NumberOfRaces { get; private set; }
        public string DriverStandings { get; private set; }
        public string ConstructorStandings { get; private set; }

        public Season(int _year, int _numberOfRaces, string _driverStandings, string _constructorStandings)
        {
            Year = _year;
            NumberOfRaces = _numberOfRaces;
            DriverStandings = _driverStandings;
            ConstructorStandings = _constructorStandings;
        }
        public Season()
        {

        }
    }
}
