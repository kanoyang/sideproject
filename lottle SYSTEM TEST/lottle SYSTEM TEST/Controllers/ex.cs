using lottle_SYSTEM_TEST.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace lottle_SYSTEM_TEST.Controllers
{
    public class ex
    {
        string strConString = @"Data Source=.;Initial Catalog=TestDB; User ID=sa;Pwd=!QAZ2wsx";

        public int MyProperty { get; set; }
        //例外處理,假如沒有name那要新增
        public void ex1_Insert_name(string sn)
        {
            using (SqlConnection con = new SqlConnection
                    (strConString))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "INSERT into [dbo].[lottle_user] (User_Name) values(@USERNAME)";
                    cmd.Parameters.AddWithValue("USERNAME", sn);
                    cmd.ExecuteNonQuery();
                    //ex(例外處理):如果有重複的人出現那要回傳說有此人存在,無法新增
                }

            }//add User_name
        }
        public void ex1_insertTi_name(string name)
        {
            using (SqlConnection con = new SqlConnection(strConString))//增加在ticket的表
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
               
                    con.Open();
                    Guid SQLiD = Guid.NewGuid();
                    cmd.CommandText =
                        @"INSERT into [dbo].[Coupon] (
                                ticket_id,
                                user_name,
                                create_time,
                                award_checkget                           
                            ) values(
                                @SQLID,
                                @Str,
                                @Create_time,
                                @award_checkget            
                                    ) ";
                    cmd.Parameters.AddWithValue("SQLID", SQLiD);
                    cmd.Parameters.AddWithValue("Str", name);
                    cmd.Parameters.AddWithValue("award_checkget", 'N');
                    DateTime nowTime =  DateTime.Now;
                    cmd.Parameters.AddWithValue("Create_time", nowTime);
                    cmd.ExecuteNonQuery();//  Must be between 1/1/1753 12:00:00 AM and Query();

                }
                //user_name into ticket and add ticketId
            };
        }

        public bool checkPerson(string USER_NAME)
        /*Check person NOt null/null */
        {
            int i = 0;//每次都是新的一次

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand
                    (
                    "SELECT *" +
                    "FROM " +
                    "[TestDB].[dbo].[lottle_user]" +
                    "WHERE User_Name = @USER_NAME ", con);


                cmd.Parameters.AddWithValue("USER_NAME", USER_NAME);

                SqlDataReader dc = cmd.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(dc);
                List<string> G = vf(table);

                if (i == 0)
                {
                    con.Close();

                    return false;

                }
                else
                {
                    con.Close();
                    return true;

                }
                List<string> vf(DataTable table)
                {
                    List<string> objectList = new List<string>();
                    foreach (DataRow dr in table.Rows)
                    {

                        string _result = dr["User_Name"].ToString();

                        objectList.Add(_result);
                        i++;//因為資料表為1時row為0,所以用i++去判斷到底有沒有被執行
                    }
                    return objectList;
                }





            }
        }

        /**********************要檢查抽獎時總數會不會小於獎品的總數*************************/
        public int check_AwardCount_Toall()
        {
            int i = 0;
            using (SqlConnection con = new SqlConnection(strConString))
            {
                string QQ = "N";
                SqlCommand cmd = new SqlCommand("SELECT * FROM [TestDB].[dbo].[Coupon] WHERE [award_checkget] = @QQ", con);//*掛在這裡VALUE
                con.Open();
                cmd.Parameters.AddWithValue("QQ", QQ);
                SqlDataReader dc = cmd.ExecuteReader();
                DataTable table = new DataTable();//create table 


                table.Load(dc);//把資料丟進來
                List<string> _list = vf(table);
                int Cou = _list.Count;
                return Cou;



                List<string> vf(DataTable table)
                {
                    List<string> objectList = new List<string>();
                    foreach (DataRow dr in table.Rows)
                    {

                        string _result = dr["award_name"].ToString();

                        objectList.Add(_result);
                        i++;
                    }
                    return objectList;
                }


            }



        }



        /***************************************檢查我的awardsId value是不是null*********************/

        public bool check_awards_id(int datalist)//input datalist 放進來檢查這個

        {

            string strConString = @"Data Source=.;Initial Catalog=TestDB; User ID=sa;Pwd=!QAZ2wsx";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT " +
                    "[award_number_T]" +
                    " FROM " +
                    "[TestDB].[dbo].[Coupon] " +
                    "  WHERE [DataList] =" +
                    " @VALUE"
                    , con);//*掛在這裡VALUE
                cmd.Parameters.AddWithValue("VALUE", datalist);
                SqlDataReader dc = cmd.ExecuteReader();
                DataTable table = new DataTable();//create table 
                table.Load(dc);//把資料丟進來               
                if (table != null && table.Rows.Count > 0)
                {
                    return true;//有值的
                }
                else
                    return false;
                



            }



        }

        /***************************************檢查random的值有沒有存在於sql*************************************************/

        public bool check_value_exSQL(int datalist)//input datalist 放進來檢查這個

        {

            string strConString = @"Data Source=.;Initial Catalog=TestDB; User ID=sa;Pwd=!QAZ2wsx";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT " +
                    "[DataList]" +
                    " FROM " +
                    "[TestDB].[dbo].[Coupon] " +
                    "  WHERE [DataList] =" +
                    " @VALUE"
                    , con);//*掛在這裡VALUE
                cmd.Parameters.AddWithValue("VALUE", datalist);
                SqlDataReader dc = cmd.ExecuteReader();
                DataTable table = new DataTable();//create table 
                table.Load(dc);//把資料丟進來
                if (table != null && table.Rows.Count > 0)
                {
                    return true;//有值的
                }
                else
                    return false;
                
            }

        }

    }
}

