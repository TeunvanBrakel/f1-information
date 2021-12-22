using System;
using System.Collections.Generic;
using System.Linq;
using f1_information_backend.Models;
using System.Threading.Tasks;
using f1_information_backend.Database;
using System.Net.Http;
using Newtonsoft.Json;

namespace f1_information_backend.Services
{
    public class DriverService
    {
        private readonly DbContext context;
        private List<Driver> Drivers { get; }
        static HttpClient client = new HttpClient();
        public DriverService(DbContext dbContext)
        {
            context = dbContext;
            Team redbull = new Team("RedBull", 203, 543);
            Team mercedes = new Team("Mercedes", 403, 555);
            Driver Max = new Driver("Max", 23, "Red bull", "https://www.formula1.com/content/fom-website/en/drivers/max-verstappen/_jcr_content/image.img.640.medium.jpg/1617101447981.jpg", 423, 19, 14, redbull);
            
            Driver Lewis = new Driver("Lewis", 34, "Mercedes", "https://cdn-9.motorsport.com/images/mgl/6xEDbp10/s8/lewis-hamilton-mercedes-1.jpg", 394, 100, 102, mercedes);
            
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
            Driver test = new Driver();
            HttpResponseMessage response = await client.GetAsync("http://ergast.com/api/f1/drivers/alonso.JSON");
            if (response.IsSuccessStatusCode)
            {
                dynamic test123 = await response.Content.ReadAsStringAsync();
                test123 = JsonConvert.DeserializeObject<object>(test123);
                Console.WriteLine(test123.MRData);
                string test4556 = JsonConvert.SerializeObject(test123.MRData.DriverTable.Drivers[0]);
                test = JsonConvert.DeserializeObject<Driver>(test4556);
            }
            /*RaceDrivers raceDrivers = new RaceDrivers();
            Race qatar = new Race("Qatar", "Jeddah", 23, "qatar international f1 race");
            raceDrivers.Race = context.Races.Find(1);
            raceDrivers.Driver = context.Drivers.Find(1);
            context.RaceDrivers.Add(raceDrivers);
            await context.SaveChangesAsync();*/
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
