using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace f1_information_backend.Models
{
    public class RaceFavorites
    {
        public int RaceId { get; set; }
        public int FavoriteRacesId { get; set; }
        public Race Race { get; set; }
        public FavoriteRaces FavoriteRaces { get; set; }
    }
}
