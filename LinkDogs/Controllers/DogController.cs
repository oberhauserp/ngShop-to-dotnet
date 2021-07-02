using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using App;

namespace LinkDogs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DogController : ControllerBase
    {
        

        private readonly ILogger<DogController> _logger;

        public DogController(ILogger<DogController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetDogs(){
            var dogs = JsonConvert.DeserializeObject<List<Dog>>(System.IO.File.ReadAllText(@"C:\Users\MWilson\nelent-projects\ngshop\LinkDogs\dogdata.json"));

            return base.Ok(dogs);

            /* return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray(); */
        }
        // [HttpGet("{id}")]
        // public IActionResult GetDogByID(string id)
        // {
        //     var dogs = JsonConvert.DeserializeObject<List<Dog>>(System.IO.File.ReadAllText(@"C:\Users\MWilson\nelent-projects\ngshop\LinkDogs\dogdata.json"));

        //     //dynamic jodogs = JObject.Parse(@"C:\Users\MWilson\nelent-projects\ngshop\LinkDogs\dogdata.json");

        //     return base.Ok(dogs.FirstOrDefault(D => D.Id == id));
        // }
    }
}
