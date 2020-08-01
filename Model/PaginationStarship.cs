using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.WebApi.Model
{
    public class PaginationStarship
    {
        public Uri Next { get; set; }

        public Uri Previous { get; set; }

        public int Count { get; set; }
        public IEnumerable<Starship> Results { get; set; }

        public Starship CalculateTravel(int megalight, int passenger)
        {
            if (Results == null)
            {
                return null;
            }

            var x = Results.Select(f => f.CalculateTravel(megalight, passenger));

            return x.OrderBy(f => f.Travel).FirstOrDefault();
        }
    }
}
