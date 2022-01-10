using f1_information_backend.Database;
using f1_information_backend.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace f1_information_backend
{
    public class Authenticater
    {

        private readonly DbContext _context;
        public Authenticater(DbContext context)
        {
            _context = context;
        }

        public Boolean Login(string userName, string password)
        {
            foreach(User user in _context.Users)
            {
                string hashed = hashedPassword(password, user.Salt);
                if(user.UserName.Equals(userName) && user.PassWord.Equals(hashed))
                {
                    return true;
                }
            }
            return false;
        }

        private string hashedPassword(string password, byte[] salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            Console.WriteLine($"Haashed:{hashed}");
            return hashed;

        }
    }
}
