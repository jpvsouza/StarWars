using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StarWars.WebApi.Model;
using System.Text.Json.Serialization;

namespace StarWars.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetController : ControllerBase
    {
        static async Task<PaginationPlanet> RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("https://swapi.dev/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("planets/");
                if (response.IsSuccessStatusCode)
                {
                    var planet = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<PaginationPlanet>(planet);
                }
                return null;
            }
        }

        [HttpGet("/planets")]
        public async Task<ActionResult<PaginationPlanet>> GetPlanetsAsync()
        {

            var planets = await RunAsync();
            if (planets == null)
            {
                return BadRequest();
            }
            return Ok(planets);
        }

        [HttpGet("/planet/{id}")]
        public async Task<ActionResult<Planet>> GetPlanetById(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("https://swapi.dev/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync($"planets/{id}/");
                if(response.IsSuccessStatusCode)
                {
                    return Ok(JsonConvert.DeserializeObject<Planet>(await response.Content.ReadAsStringAsync()));
                }
                return BadRequest();

            }
            
        }
    }
}
