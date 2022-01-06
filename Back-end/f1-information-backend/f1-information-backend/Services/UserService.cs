using f1_information_backend.Database;
using f1_information_backend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
            user.GameSettings = settings;
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return "ok";
        }
    }
}
