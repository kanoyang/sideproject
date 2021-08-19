using Login.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Interface
{
    public class DependAccountCountrol:IAccountService
    {

        public string Accountid ="Max123";

        public string Password = "test123";

        public   string Login(AccountControl User) 
        {
            if (User.AccountID == null)
            {

                return "Id為空值";

            }

            else
            {

               var request =  DependUserLogin(User);
                return "確認ID有值"+request;
            
            }
        }
        public string DependUserLogin(AccountControl User)
        {



            if (User.AccountID == Accountid || User.Password == Password)
            {

                return "登入成功";


            }

            else 
            {
                return "登入失敗";
            
            }


        }

       
    }
}
