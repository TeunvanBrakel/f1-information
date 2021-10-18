using Microsoft.AspNetCore.Mvc;
using f1_information_backend.Models;
using f1_information_backend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace f1_information_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DriverController
    {
        public DriverController()
        {
        }

        [HttpGet]
        public ActionResult<List<Driver>> GetAll() =>
            DriverService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Driver> Get(int id)
        {
            var driver = DriverService.Get(id);

            if (driver == null)
                return null;

            return driver;
        }

        // POST action

        // PUT action

        // DELETE action
    }
}
