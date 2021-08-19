using Email_test.Model;
using MailKit.Search;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Imap;
using MailKit.Security;
using MailKit;

namespace Email_test.Appaciation
{
    public class GetMailService : IGetMailService
    {
        public List<Send> GetMail(Sender user)
        {
            var client = new ImapClient();

            client.Connect("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);

            client.Authenticate(user.AccountID, user.PassWord);

            client.Inbox.Open(FolderAccess.ReadWrite);

            
            var innnerMessage = new List<Send>();
            var senderData = new Send(); 
            var uids = client.Inbox.Search(SearchQuery.NotSeen);//讀全部檔案
             
            foreach (var uid in uids)
            {
                var message = client.Inbox.GetMessage(uid);

                senderData.Receiver = message.To.ToString();
                senderData.Title = message.Subject.ToString();
                senderData.Content = message.Body.ToString();

                innnerMessage.Add(senderData);

            }
            return innnerMessage;
        }


    }
}

