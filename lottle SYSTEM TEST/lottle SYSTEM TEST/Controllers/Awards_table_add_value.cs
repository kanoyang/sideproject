using lottle_SYSTEM_TEST.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lottle_SYSTEM_TEST.Controllers
{
    public class Awards_table_add_value
    {

        string strConString = @"Data Source=.;Initial Catalog=TestDB; User ID=sa;Pwd=!QAZ2wsx";



        /*保留不刪除,讀一下sql不關閉的方法*/
        //public void putInAward_table(string Award_name, Guid Award_guid, SqlConnection conn)//同時update資料進我的award的table裡面
        //{


        //    using (SqlCommand cmd = conn.CreateCommand())
        //    {
        //        cmd.CommandText =
        //            "INSERT into [dbo].[AwardTable] (" +
        //            "Awards_Name," +
        //            "Awards_Id," +
        //            "Awards_createtime)" +
        //            " values" +
        //            "(" +
        //            "@Award_name," +
        //            "@Award_guid," +
        //            "@Awards_createtime)";
        //        cmd.Parameters.AddWithValue("Award_name", Award_name);
        //        cmd.Parameters.AddWithValue("Award_guid", Award_guid);
        //        cmd.Parameters.AddWithValue("Awards_createtime", DateTime.Now.ToString("yyyy-MM-dd"));

        //        cmd.ExecuteNonQuery();



        //    }





        //}



    }
}
