using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace f1_information_backend.Models
{
    public class GameSettings
    {
        public int Id { get; set; }
        public string DriverPicked { get; private set; }
        public string RaceGuess { get; private set; }
        public string QualyGuess { get; private set;  }
        public int Points { get; private set; }

        public GameSettings()
        {

        }

        public GameSettings(string _driverPicked, string _raceGuess, string _qualyGuess, int _points)
        {
            DriverPicked = _driverPicked;
            RaceGuess = _raceGuess;
            QualyGuess = _qualyGuess;
            Points = _points;
        }
    }
}
