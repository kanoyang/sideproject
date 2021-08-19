using MailTest.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MailTest.Application
{
    public class mailApiService : ImailApiService
    {


        public async Task<tokenResponse> login(accountdata user)
        {
            using(HttpClient client=new HttpClient()) //client.BaseAddress = new Uri("https://localhost:44380/");設基底的URL

            {
                
                client.BaseAddress = new Uri("https://localhost:44380/");
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "controler/action");
                //代表HTTP要求的訊息,(,"controler/action"))
                //也可以這樣拆
                //HttpRequestMessage request = new HttpRequestMessage();
                //request.Method = HttpMethod.Post;
                //request.RequestUri = new Uri("controler/action");

                //設定Header                                                                                                               
                //request.Headers.Add("name", "value");

                string inputjson = JsonConvert.SerializeObject(user);

            request.Content = new StringContent(inputjson, Encoding.UTF8, "application/json");//Content取得或設定Http訊息的內容,(設定body內容和格式)
          
                
                HttpResponseMessage response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();//表示成功呼叫,如果是false則擲回例外狀況

            var responseString = await response.Content.ReadAsStringAsync();
           
            tokenResponse tokenResponse = JsonConvert.DeserializeObject<tokenResponse>(responseString);//取回傳值

            return tokenResponse;

        }}

        public async Task<response> sendMail(mailrequest mail)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44380/SendMail/sendMail");
                string inputjson = JsonConvert.SerializeObject(mail);
                request.Content = new StringContent(inputjson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.SendAsync(request);
              
                var responseString = await response.Content.ReadAsStringAsync();

                tokenResponse pushResponse = JsonConvert.DeserializeObject<tokenResponse>(responseString);

                return pushResponse;
            }
        }
        public async Task<readMailResponse> GetMail(string token)
        {
            using (HttpClient client = new HttpClient())
            {
                
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44380/SendMail/readMail?token="+token);
             
                HttpResponseMessage response = await client.SendAsync(request);

                var responseString = await response.Content.ReadAsStringAsync();

                readMailResponse rR = JsonConvert.DeserializeObject<readMailResponse>(responseString);

                return rR;
            }
            
        }
    }
}
