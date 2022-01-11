using f1_information_backend.Database;
using f1_information_backend.Models;
using f1_information_backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace f1_information_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IJwtTokenManager _tokenManger;
        private readonly UserService userService;
        private readonly Authenticater authenticater;
        private int minSeconds = 5;
        private int maxSeconds = 30;
        public TokenController(IJwtTokenManager jwtTokenManager, UserService service, Authenticater _authenticater)
        {
            _tokenManger = jwtTokenManager;
            userService = service;
            authenticater = _authenticater;
        }

        /*public TokenController(UserService service)
        {
            userService = service;
        }*/

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody]UserCredential credential)
        {
            var token = "";
            if (authenticater.Login(credential.UserName, credential.Password))
            {
                string role = authenticater.GetRole(credential.UserName, credential.Password);
                if(!string.IsNullOrEmpty(role))
                {
                    token = _tokenManger.Authenticate(credential.UserName, credential.Password, role);
                }
            }
            if (string.IsNullOrEmpty(token))
            {
                Random rand = new Random();
                Thread.Sleep(rand.Next(minSeconds, maxSeconds) * 1000);
                return Unauthorized();
            }
            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost("Signup")]
        public IActionResult Signup([FromBody]User user)
        {
            var result = userService.AddUser(user);
            if (result.Result != "ok")
                return NotFound(result.Result);
            return Ok();
        }
    }
}
