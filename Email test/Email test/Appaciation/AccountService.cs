using Email_test.Model;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MailKit.Search;
using MailKit.Security;
using MimeKit;
using System.IO;
using System.Linq;


namespace Email_test.Appaciation
{
    public class AccountService : IAccountService
    {

        public bool DependAccountNull(Sender user) 
        {
            if (user.AccountID == null || user.PassWord == null)
            {
                return false;
            }
            else
            return true;

        }



        
        public string SendMail(SendertoAll user)
        {
            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse(user.sender.AccountID));
            message.To.Add(MailboxAddress.Parse(user.send.Receiver));
            message.Subject = user.send.Title;

            message.Body = new TextPart("plain")
            {
                Text = user.send.Content
            };

            using (var client = new SmtpClient())
            {

                client.Connect("imap.gmail.com", 465, SecureSocketOptions.SslOnConnect);
                client.Authenticate(user.sender.AccountID, user.sender.PassWord);
                client.Send(message);
                client.Disconnect(true);

            }

            return "完成傳送";
        }
    }
}
