using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.WebApi.Model
{
    public class Starship
	{
        public string Name { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string CostInCredits { get; set; }
        public string Length { get; set; }
        public string MaxAtmospheringSpeed { get; set; }
        public string Crew { get; set; }
        public int Passengers { get; set; }
        public string CargoCapacity { get; set; }
        public string Consumables { get; set; }
        public string HyperdriveRating { get; set; }
        public int MGLT { get; set; }
        public string StarshipClass { get; set; }
        public IEnumerable<string> Pilots { get; set; }
        public IEnumerable<string> Films { get; set; }

        public decimal Travel { get; set; }
        public string Url { get; set; }

        public int CalculateStops(int megalights)
        {
            return megalights / MGLT;
        }

        public Starship CalculateTravel(int megalight, int passengers)
        {
            if (passengers>Passengers)
            {
                return null;
            }
            var parada = CalculateStops(megalight);

            Travel = parada / passengers;
            return this;
        }


 //       "name": "Death Star",
	//"model": "DS-1 Orbital Battle Station",
	//"manufacturer": "Imperial Department of Military Research, Sienar Fleet Systems",
	//"cost_in_credits": "1000000000000",
	//"length": "120000",
	//"max_atmosphering_speed": "n/a",
	//"crew": "342,953",
	//"passengers": "843,342",
	//"cargo_capacity": "1000000000000",
	//"consumables": "3 years",
	//"hyperdrive_rating": "4.0",
	//"MGLT": "10",
	//"starship_class": "Deep Space Mobile Battlestation",
	//"pilots": [],
	//"films": [
	//	"http://swapi.dev/api/films/1/"
	//],
        
    }
}
