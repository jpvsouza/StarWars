using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StarWars.WebApi.Model;

namespace StarWars.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        static async Task<PaginationPeople> RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("https://swapi.dev/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("people/");
                if (response.IsSuccessStatusCode)
                { 
                    var people = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<PaginationPeople>(people);
                }
                return null;
            }
        }

        [HttpGet("/peoples")]
        public async Task<ActionResult<PaginationPeople>> GetPeoplesAsync ()
        {

            var peoples = await RunAsync();
            if (peoples == null)
            {
                return BadRequest();
            }
            return Ok(peoples);
        }

        [HttpGet("/people/{id}")]
        public async Task<ActionResult<People>> GetPeopleById (int id)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("https://swapi.dev/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync($"people/{id}/");
                if (response.IsSuccessStatusCode)
                {
                    return Ok(JsonConvert.DeserializeObject<People>(await response.Content.ReadAsStringAsync()));
                }
                return NotFound();
            }
        }
    }
}
