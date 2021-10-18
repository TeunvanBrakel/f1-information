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

        public Driver(string _name, int _age, string _currentTeam)
        {
            Name = _name;
            Age = _age;
            CurrentTeam = _currentTeam;
        }
    }
}
