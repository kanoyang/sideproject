using lottle_SYSTEM_TEST_FourQuestinon.modle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace lottle_SYSTEM_TEST_FourQuestinon.work
{
    public class select_data
    {
        string strConString = @"Data Source=.;Initial Catalog=TestDB; User ID=sa;Pwd=!QAZ2wsx";


        public List<ticket> select_ANB(int number)
        {

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select " +
                    "[user_name] , " +
                    "[award_number_T] " +
                    " from " +
                    "[dbo].[Coupon] " +
                    " where award_number_T = @number "
                    , con);
                cmd.Parameters.AddWithValue("number", number);
                SqlDataReader dc = cmd.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(dc);
                List<ticket> z = ShowMessage(table);
                return z;
                //*_list.FirstOrDefault


            }
        }

        public List<ticket> ShowMessage(DataTable table)

        {

            List<ticket> objectList = new List<ticket>();
            foreach (DataRow dr in table.Rows)
            {
             
                ticket _result = new ticket();
                _result.User_name = dr["user_name"].ToString();
                _result.award_number_T = Convert.ToInt32(dr["award_number_T"]);

                //_result.ticket_id = Guid.Parse(dr["ticket_id"].ToString());
                //_result.Awards_name = dr["award_name"].ToString();
                // _result.create_tumes = DateTime.Parse(dr["create_time"].ToString());
                objectList.Add(_result);
            }
            return objectList;



        }


    }
}
