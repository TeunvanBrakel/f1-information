using System;
using System.Collections.Generic;
using System.Linq;
using f1_information_backend.Models;
using System.Threading.Tasks;
using f1_information_backend.Database;

namespace f1_information_backend.Services
{
    public class DriverService
    {
        private readonly DbContext context;
        private List<Driver> Drivers { get; }
        public DriverService(DbContext dbContext)
        {
            context = dbContext;
            Driver Max = new Driver("Max", 23, "Red bull", "https://www.formula1.com/content/fom-website/en/drivers/max-verstappen/_jcr_content/image.img.640.medium.jpg/1617101447981.jpg", 423, 19, 14);
            
            Driver Lewis = new Driver("Lewis", 34, "Mercedes", "https://cdn-9.motorsport.com/images/mgl/6xEDbp10/s8/lewis-hamilton-mercedes-1.jpg", 394, 100, 102);
            
            Drivers = new List<Driver>
            {
                Max,
                Lewis,
            };
            Test();
        }
        private async void Test()
        {
            if (context.Drivers.Count() < 2)
            {
                await Add(Drivers[0]);
                await Add(Drivers[1]);
            }
        }

        public List<Driver> GetAll()
        {
            var result = context.Drivers.ToList();
            return result;
        }

        public Driver Get(int id)
        {
            var result = context.Drivers.Find(id);
            return result;
        }

        public async Task Add(Driver driver)
        {
            context.Drivers.Add(driver);
            await context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var driver = Get(id);
            if (driver is null)
                return;

            context.Drivers.Remove(driver);
        }

        public void Update(Driver driver)
        {
            var index = Drivers.FindIndex(p => p.Id == driver.Id);
            if (index == -1)
                return;

            Drivers[index] = driver;
        }
    }
}
