using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailTest.Models
{
    public class mail
    {
        public string Receiver { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

    }

    public class mailrequest:mail
    {
        public string token { get; set; }
    }
    
}
