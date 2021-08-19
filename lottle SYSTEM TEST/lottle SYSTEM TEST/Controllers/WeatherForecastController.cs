using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using lottle_SYSTEM_TEST.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using lottle_SYSTEM_TEST.Controllers;

namespace lottle_SYSTEM_TEST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        string strConString = @"Data Source=.;Initial Catalog=TestDB; User ID=sa;Pwd=!QAZ2wsx";
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        //[HttpGet]
       // public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        [HttpPost]
        public List<ticket> Post(ticket Sname)
        {

            ex Ex = new ex();

            bool c = Ex.checkPerson(Sname.User_name);//檢查是否有出現在user的table裡面true:假如人已經存在;false反之亦然



            if (c != true)
            {
                Ex.ex1_Insert_name(Sname.User_name);

                Ex.ex1_insertTi_name(Sname.User_name);
            }

            else
            {
                Ex.ex1_insertTi_name(Sname.User_name);

            }

            return Get();


        }

    

        [HttpGet]
        public List<ticket> Get()
        {

            using (SqlConnection con = new SqlConnection(strConString))
            {
                SqlCommand cmd = new SqlCommand("select *" +
                    " from " +
                    "[dbo].[Coupon]" +
                    " order by  [create_time] "
                    , con);
                con.Open();
                SqlDataReader dc = cmd.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(dc);
                List<ticket> _list = ShowMessage2(table);
                return _list;
            }
        }
        List<ticket> ShowMessage2(DataTable table)
        {
            List<ticket> objectList = new List<ticket>();
            foreach (DataRow dr in table.Rows)
            {
                ticket _result = new ticket();

                _result.User_name = dr["user_name"].ToString();
                _result.ticket_id = Guid.Parse(dr["ticket_id"].ToString());
                _result.Awards_name = dr["award_name"].ToString();
                _result.create_tumes =DateTime.Parse(dr["create_time"].ToString());
                objectList.Add(_result);
            }
            return objectList;
        }



        [HttpPut]
        public List<ticket> Put(Awards_information putin_number)//update 
        {





            List<ticket> list = Get();

            return list;


        }







    }
}

