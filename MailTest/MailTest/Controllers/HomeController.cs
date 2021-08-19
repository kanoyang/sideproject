using MailTest.Application;
using MailTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MailTest.Controllers
{
    public class HomeController : Controller
    {
      

        private readonly ImailApiService _mailApiService;


        public HomeController(ImailApiService mailApiService)
        {
            _mailApiService = mailApiService;


        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult SendMail(mail mail)
        {
            return View();
        }
        public IActionResult SendMailTo(mail mail)
        {
            try
            {
                mailrequest mailrequest = new mailrequest() { Receiver = mail.Receiver, Title = mail.Title, Content = mail.Content, token = (string)TempData.Peek("token") };
                response sendmailResponse = _mailApiService.sendMail(mailrequest).Result;
                ViewBag.Test = mail.Content;
                TempData["result"] = sendmailResponse.remark;

            }
            catch (Exception)
            {

                TempData["result"] = "連接web api失敗，信件無法寄出";
            }


            return View("SendMail");
        }


        public IActionResult ReadMail()
        {
            //假設用信件集合
            //List<mail> ltest = new List<mail>() {
            //     new mail(){Reciever="Tom",Title="1號信件",Content="1號信件內容"},
            //     new mail(){Reciever="Tom",Title="2號信件",Content="2號信件內容"},
            //     new mail(){Reciever="Tom",Title="3號信件",Content="3號信件內容"}
            // };
            try
            {
                readMailResponse readMailResponse = _mailApiService.GetMail(TempData.Peek("token").ToString()).Result;
                var data = readMailResponse.mailList;
                TempData["result"] = readMailResponse.remark;
                return View(data);
            }
            catch (Exception)
            {
                TempData["result"] = "連接web api失敗";

            }
            return View();
        }



        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult loginTo(accountdata user)
        {
            try
            {
                tokenResponse token = _mailApiService.login(user).GetAwaiter().GetResult();
                ViewBag.result = token.remark;
                TempData["token"] = token.token;


            }
            catch (Exception)
            {
                ViewBag.result = "失敗";

            }


            return View("login");

        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
