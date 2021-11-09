using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace f1_information_backend.Models
{
    public class Team
    {
        public int Team_id { get; set; }
        private string teamName;
        private int wins;
        private int points;

        public Team(string _teamName, int _wins, int _points)
        {
            teamName = _teamName;
            wins = _wins;
            points = _points;
        }
    }
}
