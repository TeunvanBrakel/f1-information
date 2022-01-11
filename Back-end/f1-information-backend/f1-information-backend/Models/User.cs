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
        public int GameSettingsId { get; private set; }
        public string Role { get; set; }
        public byte[] Salt { get; set; }
        public GameSettings GameSettings { get; set; }
        public ICollection<RaceFavorites> RaceFavorites { get; set; }
        public ICollection<DriverFavorites> DriverFavorites { get; set; }

        //public ICollection<UserRole> UserRole { get; set; }

        public User()
        {

        }

        public User(string _userName, string _passWord, string _email, byte[] salt, int code)
        {
            UserName = _userName;
            PassWord = _passWord;
            Email = _email;
            Salt = salt;
            SetRole(code);
        }

        public int getId()
        {
            return Id;
        }
        public string getUsername()
        {
            return UserName;
        }

        private void SetRole(int code)
        {
            if(code == 20011002)
            {
                Role = "Admin";
            }
            else
            {
                Role = "User";
            }
        }
    }
}
