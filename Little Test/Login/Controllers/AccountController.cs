using Login.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {


        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Login(AccountControl account)
        {
          var result =   _service.Login(account);

            return Ok(result);
        }



       
    }
}
