using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace f1_information_backend.Models
{
    public class Race
    {
        public int Race_id { get; set; }
        private string country;
        private string circuit;
        private int season;
        private int raceNumber;
        private string raceName;

        public Race(string _country, string _circuit, int _season, int _raceNumber, string _raceName)
        {
            country = _country;
            circuit = _circuit;
            season = _season;
            raceNumber = _raceNumber;
            raceName = _raceName;
        }
    }
}
