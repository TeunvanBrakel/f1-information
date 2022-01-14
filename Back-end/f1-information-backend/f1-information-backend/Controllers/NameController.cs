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
                    user.Role,
                    user.Reports.ToString(),
                    user.Banned.ToString()
                };
                allNames.Add(userInfo);
            }
            return Ok(allNames);
        }

        [AllowAnonymous]
        [HttpGet("UserNames")]
        public IActionResult GetUserNames()
        {
            List<User> allUsers = userService.GetUsers();
            List<string> allNames = new List<string>();
            foreach (User user in allUsers)
            {
                allNames.Add(user.UserName);
            }
            return Ok(allNames);
        }

        [AllowAnonymous]
        [HttpPost("ReportUser")]
        public IActionResult ReportUser([FromBody]User reportedUser)
        {
            List<User> allUsers = userService.GetUsers();
            foreach(User user in allUsers)
            {
                if(user.UserName == reportedUser.UserName)
                {
                    user.Reports = user.Reports + 1;
                    userService.ChangeUser(user);
                    Console.WriteLine(reportedUser.UserName);
                    return Ok(user.Email);
                }
            }
            return NotFound();
        }

        [AllowAnonymous]
        [HttpPost("BanUser")]
        public IActionResult BanUser([FromBody] User reportedUser)
        {
            List<User> allUsers = userService.GetUsers();
            foreach (User user in allUsers)
            {
                if (user.UserName == reportedUser.UserName)
                {
                    user.Banned = true;
                    userService.ChangeUser(user);
                    Console.WriteLine(reportedUser.UserName);
                    return Ok();
                }
            }
            return NotFound();
        }

        [Authorize]
        [HttpPost("UnBanUser")]
        public IActionResult UnBanUser([FromBody] User reportedUser)
        {
            List<User> allUsers = userService.GetUsers();
            foreach (User user in allUsers)
            {
                if (user.UserName == reportedUser.UserName)
                {
                    user.Banned = false;
                    userService.ChangeUser(user);
                    Console.WriteLine(reportedUser.UserName);
                    return Ok();
                }
            }
            return NotFound();
        }
    }
}
