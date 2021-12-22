using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace f1_information_backend.Models
{
    public class Race
    {
        public int Id { get; set; }
        public string Country { get; private set; }
        public string Circuit { get; private set; }
        public int RaceNumber { get; private set; }
        public string RaceName { get; private set; }

        public ICollection<RaceSeason> Seasons { get; set; }
        public ICollection<RaceDrivers> Drivers { get; set; }
        public ICollection<RaceResult> Results { get; set; }
        public ICollection<RaceFavorites> RaceFavoritesUser { get; set; }

        public Race(string _country, string _circuit, int _raceNumber, string _raceName)
        {
            Country = _country;
            Circuit = _circuit;
            RaceNumber = _raceNumber;
            RaceName = _raceName;
        }
        public Race()
        {

        }
    }
}
