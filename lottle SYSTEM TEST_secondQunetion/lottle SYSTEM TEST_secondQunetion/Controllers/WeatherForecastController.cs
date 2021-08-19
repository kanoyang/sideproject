using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using lottle_SYSTEM_TEST_secondQunetion.modle;
using lottle_SYSTEM_TEST_secondQunetion.work;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace lottle_SYSTEM_TEST_secondQunetion.Controllers
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





        [HttpPost]
        public List<ticket> Post(ticket Sname)
        {

            select_data data = new select_data();

           return data.select_PTi(Sname.User_name);



        }






    }
    }
