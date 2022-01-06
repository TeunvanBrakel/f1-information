using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace f1_information_backend
{
    public interface IJwtTokenManager
    {
        string Authenticate(string userName, string password);
    }
}
