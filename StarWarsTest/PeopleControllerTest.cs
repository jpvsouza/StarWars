using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StarWars.WebApi.Controllers;
using StarWars.WebApi.Model;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StarWarsTest
{
    public class PeopleControllerTest
    {
        private PeopleController _controller;

        public PeopleControllerTest()
        {
            _controller = new PeopleController();
        }

        [Fact]
        public async Task DeveRetornarTodasPessoasPaginadas()
        {
            using (var file = new StreamReader(File.OpenRead("Fixtures/GetAllPeople.json")))
            {
                var people = file.ReadToEnd();
                var expected = JsonConvert.DeserializeObject<PaginationPeople>(people);

                var result = await _controller.GetPeoplesAsync();

                var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
                var actual = Assert.IsType<PaginationPeople>(okObjectResult.Value);
                Assert.Equal(expected.Count, actual.Count);
                Assert.Equal(expected.Results.First().Name, actual.Results.First().Name);
                Assert.Equal(expected.Results.Last().Name, actual.Results.Last().Name);
                
                
            }
        }
    }
}
