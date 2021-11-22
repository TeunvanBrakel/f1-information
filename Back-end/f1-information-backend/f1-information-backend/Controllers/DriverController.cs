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
        private readonly DriverService driverService;
        public DriverController(DriverService service)
        {
            driverService = service;
        }

        [HttpGet]
        public ActionResult<List<Driver>> GetAll() =>
            driverService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Driver> Get(int id)
        {
            var driver = driverService.Get(id);

            if (driver == null)
                return null;

            return driver;
        }
        [HttpPost]
        public async void CreateDriver(Driver driver)
        {
            if(driver != null)
            {
                await driverService.Add(driver);
            }
        }
        // POST action

        [HttpPut("{id}")]
        public ActionResult Update(int id, Driver driver)
        {
            if(driver.Id == id)
            {
                driverService.Update(driver);
                return new OkResult();
            }
            return new BadRequestResult();
        }
        // PUT action

        // DELETE action
    }
}
