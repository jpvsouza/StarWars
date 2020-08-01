using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.WebApi.Model
{
    public class Planet
	{
        public string Name { get; set; }
        public string RotationPeriod { get; set; }
        public string OrbitalPeriod { get; set; }
        public string Diameter { get; set; }
        public string Climate { get; set; }
        public string Gravity { get; set; }
        public string Terrain { get; set; }
        public string SurfaceWater { get; set; }
        public string Population { get; set; }
        public IEnumerable<string> Residents { get; set; }
        public IEnumerable<string> Films { get; set; }
        public string Url { get; set; }

        //       "name": "Yavin IV",
        //"rotation_period": "24",
        //"orbital_period": "4818",
        //"diameter": "10200",
        //"climate": "temperate, tropical",
        //"gravity": "1 standard",
        //"terrain": "jungle, rainforests",
        //"surface_water": "8",
        //"population": "1000",
        //"residents": [],
        //"films": [
        //	"http://swapi.dev/api/films/1/"
        //],
    }
}
