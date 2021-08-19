using Email_test.Appaciation;
using Email_test.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Email_test.Controllers

{    [Route("api/[controller]")]
     [ApiController]
    public class SendMailController : Controller
    {
        private readonly IAccountService _accountService;

        public SendMailController(IAccountService accountService ) 
        {

            _accountService = accountService;
        
        }

        [HttpPost]
        public IActionResult Login([FromBody] SendertoAll user)
        {
            var result = _accountService.SendMail(user) ;
            

            return Ok(result);
        }
        [HttpGet("hi")]

        public IActionResult Rest()
        {
            return Ok("hi");
        }

        
    }
}
