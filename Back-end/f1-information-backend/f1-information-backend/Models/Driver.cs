using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace f1_information_backend.Models
{
    public class Driver
    {
        public int Id { get; set; }
        private string name;
        private int age;
        private string currentTeam;

        public Driver(string _name, int _age, string _currentTeam)
        {
            name = _name;
            age = _age;
            currentTeam = _currentTeam;
        }
    }
}
