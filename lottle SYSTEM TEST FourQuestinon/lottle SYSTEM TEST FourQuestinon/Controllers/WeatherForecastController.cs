using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lottle_SYSTEM_TEST_FourQuestinon.modle;
using lottle_SYSTEM_TEST_FourQuestinon.work;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace lottle_SYSTEM_TEST_FourQuestinon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }




        [HttpPost]
        public List<ticket> Post(ticket number)
        {

            select_data data = new select_data();

            return data.select_ANB(number.award_number_T);



    
        }






    }
}
