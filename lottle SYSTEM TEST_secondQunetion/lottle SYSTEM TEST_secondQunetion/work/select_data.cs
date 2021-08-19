using lottle_SYSTEM_TEST_secondQunetion.modle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace lottle_SYSTEM_TEST_secondQunetion.work
{
    public class select_data
    {
        string strConString = @"Data Source=.;Initial Catalog=TestDB; User ID=sa;Pwd=!QAZ2wsx";


        public List<ticket> select_PTi(string name )
        {

            using (SqlConnection con = new SqlConnection(strConString))
            {con.Open();
                SqlCommand cmd = new SqlCommand("select " +
                    "[ticket_id]," +
                     "[award_checkget]," +
                     "[create_time]," +
                     "[award_name] ," +
                     "[user_name] " +

                    " from " +
                    "[dbo].[Coupon] " +
                    " where user_name = @name "
                    , con);
                cmd.Parameters.AddWithValue("name", name);
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
                _result.award_checkget = dr["award_checkget"].ToString();
                _result.ticket_id = Guid.Parse(dr["ticket_id"].ToString());
                _result.Awards_name = dr["award_name"].ToString();
                _result.create_tumes = DateTime.Parse(dr["create_time"].ToString());
                objectList.Add(_result);
            }
            return objectList;



        }

    }







}

