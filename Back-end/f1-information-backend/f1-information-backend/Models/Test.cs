using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace f1_information_backend.Models
{
    public class Test
    {
        public string driverId { get; set; }
        public string code { get; set; }
        public string url { get; set; }
        public int PermanentNumber { get; set; }
        public string GivenName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }

        public Test()
        {

        }
        public Test(string _driverId, string _code, string _url, int _permanentNumber, string _givenName, DateTime _dateOfBirth, string _nationality)
        {
            driverId = _driverId;
            code = _code;
            url = _url;
            PermanentNumber = _permanentNumber;
            GivenName = _givenName;
            DateOfBirth = _dateOfBirth;
            Nationality = _nationality;
        }
    }
}
