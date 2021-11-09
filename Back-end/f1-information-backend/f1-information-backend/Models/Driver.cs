using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace f1_information_backend.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; }
        public int Age { get; set; }
        public string CurrentTeam { get; set; }
        public int CurrentPoints { get; set; }
        public int Wins { get; set; }
        public int PolePositions { get; set; }
        public string Image { get; set; }

        public Driver(string _name, int _age, string _currentTeam, string _image, int _currentPoints, int _wins, int _polePositions)
        {
            Name = _name;
            Age = _age;
            CurrentTeam = _currentTeam;
            Image = _image;
            CurrentPoints = _currentPoints;
            Wins = _wins;
            PolePositions = _polePositions;
        }
    }
}
