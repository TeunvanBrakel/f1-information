using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace f1_information_backend.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamName { get; private set; }
        public int Wins { get; private set; }
        public int Points { get; private set; }

        public Team(string _teamName, int _wins, int _points)
        {
            TeamName = _teamName;
            Wins = _wins;
            Points = _points;
        }
        public Team()
        {

        }
    }
}
