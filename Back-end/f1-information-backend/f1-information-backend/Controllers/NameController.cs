using f1_information_backend.Models;
using f1_information_backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace f1_information_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NameController : ControllerBase
    {
        private readonly UserService userService;
        public NameController(UserService service)
        {
            userService = service;
        }

        [AllowAnonymous]
        [HttpPost("GetNames")]
        public IActionResult GetNames()
        {
            List<User> allUsers = userService.GetUsers();
            List<object> allNames= new List<object>();
            foreach(User user in allUsers)
            {
                List<string> userInfo = new List<string>
                {
                    user.UserName,
                    user.Email,
                    user.Role
                };
                allNames.Add(userInfo);
            }
            return Ok(allNames);
        }
    }
}
