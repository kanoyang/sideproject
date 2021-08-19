using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailTest.Models
{
    public class response
    {
        public bool message { get; set; }
        public string remark { get; set; }
    }

    public class tokenResponse : response
    {
        public string token { get; set; }
    }

    public class readMailResponse : response
    {
        public List<mail> mailList { get; set; }
    }
}
