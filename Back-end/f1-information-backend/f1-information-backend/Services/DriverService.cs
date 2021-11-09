using System;
using System.Collections.Generic;
using System.Linq;
using f1_information_backend.Models;
using System.Threading.Tasks;

namespace f1_information_backend.Services
{
    public static class DriverService
    {
        static List<Driver> Drivers { get; }
        static int nextId = 3;
        static DriverService()
        {
            Driver Max = new Driver("Max", 23, "Red bull", "https://www.formula1.com/content/fom-website/en/drivers/max-verstappen/_jcr_content/image.img.640.medium.jpg/1617101447981.jpg", 423, 19, 14) { Id = 1 };
            Driver Lewis = new Driver("Lewis", 34, "Mercedes", "https://cdn-9.motorsport.com/images/mgl/6xEDbp10/s8/lewis-hamilton-mercedes-1.jpg", 394, 100, 102) { Id = 2 };
            Drivers = new List<Driver>
            {
                Max,
                Lewis,
            };
        }

        public static List<Driver> GetAll() => Drivers;

        public static Driver Get(int id) => Drivers.FirstOrDefault(p => p.Id == id);

        public static void Add(Driver driver)
        {
            driver.Id = nextId++;
            Drivers.Add(driver);
        }

        public static void Delete(int id)
        {
            var driver = Get(id);
            if (driver is null)
                return;

            Drivers.Remove(driver);
        }

        public static void Update(Driver driver)
        {
            var index = Drivers.FindIndex(p => p.Id == driver.Id);
            if (index == -1)
                return;

            Drivers[index] = driver;
        }
    }
}
