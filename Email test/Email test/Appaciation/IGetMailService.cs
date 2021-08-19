using Email_test.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Email_test.Appaciation
{
  public  interface IGetMailService
    {
        public List<Send>  GetMail(Sender user);


    }
}
