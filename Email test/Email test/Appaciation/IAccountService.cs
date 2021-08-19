using Email_test.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Email_test.Appaciation
{
  public  interface IAccountService
    {



        public bool DependAccountNull(Sender user);

        public string SendMail(SendertoAll user);




    }
}
