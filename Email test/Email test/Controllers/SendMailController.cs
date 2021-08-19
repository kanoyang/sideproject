using Email_test.Appaciation;
using Email_test.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Email_test.Controllers

{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SendMailController : Controller
    {
        private readonly IAccountService _accountService;

        public SendMailController(IAccountService accountService ) 
        {

            _accountService = accountService;
        
        }
     
        [HttpPost]
        public IActionResult Send([FromBody] SendertoAll user)
        {
            var result = _accountService.SendMail(user) ;
            

            return Ok(result);
        }


        [HttpPost]
        public IActionResult Login([FromBody] Sender user)
        {

           var Request =  _accountService.DependAccountNull(user);


            return Ok(Request);
        }




    }
}
