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
            Drivers = new List<Driver>
            {
                new Driver("Max", 23, "Red bull") { Id = 1},
                new Driver("Lewis", 34, "Mercedes") { Id = 2}
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
