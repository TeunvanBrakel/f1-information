using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace f1_information_backend.Models
{
    public class FavoriteRaces
    {
        public int Id { get; set; }
        public int UserId { get; private set; }
        public int RaceId { get; private set; }

        public ICollection<RaceFavorites> Races { get; set; }

        public FavoriteRaces()
        {

        }

        public FavoriteRaces(int _userId, int _raceId)
        {
            UserId = _userId;
            RaceId = _raceId;
        }
    }
}
