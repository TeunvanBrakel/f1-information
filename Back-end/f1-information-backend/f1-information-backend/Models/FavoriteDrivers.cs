using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace f1_information_backend.Models
{
    public class FavoriteDrivers
    {
        public int Id { get; set; }
        public int DriverId { get; private set; }
        public int UserId { get; private set; }

        public ICollection<DriverFavorites> Drivers { get; set; }

        public FavoriteDrivers()
        {

        }

        public FavoriteDrivers(int _driverId, int _userId)
        {
            DriverId = _driverId;
            UserId = _userId;
        }
    }
}
