using f1_information_backend.Database;
using f1_information_backend.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace f1_information_backend.Services
{
    public class UserService
    {
        private readonly DbContext context;

        public UserService(DbContext _context)
        {
            context = _context;
        }

        public async Task<string> AddUser(User user)
        {
            GameSettings settings = new GameSettings("", "", "", 0);
            user = HashedPassword(user);
            string isUserInputOK = CheckUserInput(user);
            if (isUserInputOK == "ok")
            {
                user.GameSettings = settings;
                context.Users.Add(user);
                await context.SaveChangesAsync();
                return "ok";
            }
            else
            {
                return isUserInputOK;
            }

        }

        public List<User> GetUsers()
        {
            return context.Users.ToList();
        }
        public void ChangeUser(User user)
        {
            context.Users.Update(user);
            context.SaveChangesAsync();
        }

        private string CheckUserInput(User user)
        {
            if(user.UserName.Length > 20)
            {
                return "Username is to long";
            }else if (!CheckMail(user.Email))
            {
                return "Mail is not valid";
            }
            else
            {
                return "ok";
            }
        }

        private bool CheckMail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }

        }

        private User HashedPassword(User user)
        {
            User result = user;
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }
            result.Salt = salt;
            Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: result.PassWord,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            Console.WriteLine($"Haashed:{hashed}");
            result.PassWord = hashed;
            return result;

        }
    }
}
