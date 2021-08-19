using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using lottle_SYSTEM_TEST.Controllers;
using lottle_SYSTEM_TEST.model;

namespace lottle_SYSTEM_TEST.Controllers
{
    public class awrds
    {
        //要再增加獎品的名稱,直接put(awrds a)再來呼叫amethod,math.random找sqlid
        public Guid Awards_Id { get; set; }

        public int pick_value { get; set; }//由使用者輸入總共抽幾個
        public int checkSqlvalue { get; set; }
        public bool checkAward { get; set; }
       

       
        string strConString = @"Data Source=.;Initial Catalog=TestDB; User ID=sa;Pwd=!QAZ2wsx";




        //***************************************抽獎系統*************************************************/
        public string test_pick_number(int i,int number)
        {
            ex Ex = new ex();
            /*
                  math.random
            ticket裡面的award_id是否是null
                 if()
             */
            //Ex 判斷NULL會不會小於獎品

            if (Ex.check_AwardCount_Toall() >= 3)//abc獎必抽,我的null的值必須要大於等於三
            {
                Random run = new Random();
                for (int R = 0; R < 100000; R++)
                {
                    checkSqlvalue = run.Next(1, 3000);

                    if (Ex.check_value_exSQL(checkSqlvalue) == true)
                    {
                        if (Ex.check_awards_id(checkSqlvalue) == true)
                        {
                            checkAward = true;
                            break;
                        }
                    }
                }
                if (checkAward == true)
                {
                    using (SqlConnection conn = new SqlConnection(strConString))
                    {
                        conn.Open();
                        string strMsgUpdate =
                            @"INSERT INTO [dbo].[Coupon]
                         (
                            award_name ,
                            award_number_T      
                                )
                              VALUES
                        (
                            ( SELECT top 1  award_name 
                              FROM [dbo].[AwardTable]
                           where Awards_list  =  @Awards_list ),
                                @award_number_T)
                            where DataList = @checkSqlvalue";
               
                        SqlCommand cmd = new SqlCommand(strMsgUpdate, conn);
                        cmd.Parameters.AddWithValue("@checkSqlvalue", checkSqlvalue);//抽的號碼
                        cmd.Parameters.AddWithValue("@Awards_list", i);//獎項
                        cmd.Parameters.AddWithValue("@award_number_T", number);//第幾次抽到
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                    return "再多加一點人";
            }
            return "";
        }
    }
}










