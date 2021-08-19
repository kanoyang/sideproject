using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lottle_SYSTEM_TEST_secondQunetion.modle;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lottle_SYSTEM_TEST_secondQunetion.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
       

        // GET api/<SampleController>/5
        /// <summary>
        /// 查詢會員身上有多少抽獎券
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public string QueryMemberTicket(int id)
        {
            return "value";
        }

        // POST api/<SampleController>
        /// <summary>
        /// 獲取抽獎券
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public void GetTicket([FromBody] ticket value)
        {
            ///
        }

        // PUT api/<SampleController>/5
        [HttpPost]
        public void ReleaseAward(int id, [FromBody] string value)
        {

        }
        // GET: api/<SampleController>
        [HttpPost]
        public IEnumerable<string> QueryAward()
        {
            return new string[] { "value1", "value2" };
        }

       
    }
}
