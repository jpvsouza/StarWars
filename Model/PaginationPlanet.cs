using StarWars.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.WebApi.Model
{
    public class PaginationPlanet
    {
        public Uri Next { get; set; }

        public Uri Previous { get; set; }

        public int Count { get; set; }
        public IEnumerable<Planet> Results { get; set; }
    }
}
