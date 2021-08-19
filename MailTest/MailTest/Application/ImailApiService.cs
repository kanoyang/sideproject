using MailTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailTest.Application
{
    public interface ImailApiService
    {
        public Task<tokenResponse> login(accountdata user);
        public Task<response> sendMail(mailrequest mail);
        public Task<readMailResponse> GetMail(string token);
    }
}
