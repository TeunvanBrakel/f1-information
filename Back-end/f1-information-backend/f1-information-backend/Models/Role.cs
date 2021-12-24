using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace f1_information_backend.Models
{
    public enum roles
    {
        ROLE_USER,
        ROLE_MODERATOR,
        ROLE_ADMIN
    }
    public class Role
    {
        public int id { get; set; }
        public roles name { get; set; }
        public ICollection<UserRole> User { get; set; }
        public Role()
        {

        }
        public Role(roles name)
        {
            this.name = name;
        }
        public int getId()
        {
            return id;
        }
        public roles getName()
        {
            return name;
        }
        public void setName(roles name)
        {
            this.name = name;
        }
    }
}
