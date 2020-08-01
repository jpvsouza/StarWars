using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.WebApi.Model
{
    public class People
    {
        public string Name { get; set; }
        public int Height { get; set; }
        public int Mass { get; set; }
        public string HairColor { get; set; }
        public string SkinColor { get; set; }
        public int BirthYear { get; set; }
        public string Gender { get; set; }
        public string HomeWorld { get; set; }
        public IEnumerable<string> Films { get; set; }
        public IEnumerable<string> Species { get; set; }
        public IEnumerable<string> Vehicles { get; set; }
        public IEnumerable<string> Starships { get; set; }
        public string  Url { get; set; }

    }
}
