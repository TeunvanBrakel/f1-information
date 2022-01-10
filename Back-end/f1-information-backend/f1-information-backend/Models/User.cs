using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace f1_information_backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Email { get; set; }
        public int GameSettingsId { get; set; }

        public byte[] Salt { get; set; }
        public GameSettings GameSettings { get; set; }
        public ICollection<RaceFavorites> RaceFavorites { get; set; }
        public ICollection<DriverFavorites> DriverFavorites { get; set; }

        //public ICollection<UserRole> UserRole { get; set; }

        public User()
        {

        }

        public User(string _userName, string _passWord, string _email, byte[] salt)
        {
            UserName = _userName;
            PassWord = _passWord;
            Email = _email;
            Salt = salt;
        }

        public int getId()
        {
            return Id;
        }
        public string getUsername()
        {
            return UserName;
        }
    }
}
