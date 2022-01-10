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
            user = hashedPassword(user);
            user.GameSettings = settings;
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return "ok";
        }

        private User hashedPassword(User user)
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
