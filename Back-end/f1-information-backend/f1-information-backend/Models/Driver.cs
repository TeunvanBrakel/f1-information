using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace f1_information_backend.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string CurrentTeam { get; private set; }
        public int CurrentPoints { get; private set; }
        public int Wins { get; private set; }
        public int PolePositions { get; private set; }
        public string Image { get; private set; }

        public Team Team { get; private set; }
        public ICollection<RaceDrivers> Races { get; set; }

        public Driver(string _name, int _age, string _currentTeam, string _image, int _currentPoints, int _wins, int _polePositions, Team team)
        {
            Name = _name;
            Age = _age;
            CurrentTeam = _currentTeam;
            Image = _image;
            CurrentPoints = _currentPoints;
            Wins = _wins;
            PolePositions = _polePositions;
            Team = team;
        }
        public Driver()
        {

        }
        private int[] test = new int[100];
        public void Test()
        {
        }
    }
}
