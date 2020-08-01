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

namespace StarWars.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StarshipController : ControllerBase
    {
        static async Task<PaginationStarship> RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("https://swapi.dev/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("starships/");
                if (response.IsSuccessStatusCode)
                {
                    var starship = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<PaginationStarship>(starship);
                }
                return null;
            }
        }

        [HttpGet("/starships")]
        public async Task<ActionResult<PaginationStarship>> GetStarshipsAsync()
        {

            var starships = await RunAsync();
            if (starships == null)
            {
                return BadRequest();
            }
            return Ok(starships);
        }
    }
}
