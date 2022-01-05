using f1_information_backend.Database;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if (!_context.Users.Any(x => x.UserName.Equals(userName)
              && x.PassWord.Equals(password)))
                return false;
            return true;
        }
    }
}
