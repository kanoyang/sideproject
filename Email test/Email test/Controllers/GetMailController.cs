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
    public class GetMailController : Controller
    {


        private readonly IGetMailService _getMail;
        
        public GetMailController(IGetMailService getService)
        {
            _getMail = getService;
        
        }
 
        public IActionResult  Getmail([FromBody] Sender user)
        { 
           var a =  _getMail.GetMail(user);

            return View(a);
        }


    }
}
