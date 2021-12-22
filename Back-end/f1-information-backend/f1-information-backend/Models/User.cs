using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace f1_information_backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; private set; }
        public string PassWord { get; private set; }

        public int GameSettingsId { get; set; }
        public GameSettings GameSettings { get; set; }
        public ICollection<RaceFavorites> RaceFavorites { get; set; }
        public ICollection<DriverFavorites> DriverFavorites { get; set; }

        public User()
        {

        }

        public User(string _userName, string _passWord)
        {
            UserName = _userName;
            PassWord = _passWord;
        }

    }
}
