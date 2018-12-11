using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication19.Models
{
    public class adminlogin
    {
         public string email  { get; set; }
        public string passward { get; set; }

        public adminlogin(string passward, string email)
        {
            this.email = email;

            this.passward = passward;
        }
    
        public static string e = "";
        public static string p = "";
        public  DataTable get_data(adminlogin i)
        {
            SqlCommand sq_com = new SqlCommand("[adminloginn]", Class1.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;
            sq_com.Parameters.AddWithValue("@email", i.passward);

            sq_com.Parameters.AddWithValue("@passward", i.email);
            //object val = sq_com.ExecuteScalar();
            SqlDataAdapter sda = new SqlDataAdapter(sq_com);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;

            
            //int s = int.Parse(sq_com.ExecuteScalar());
            //return s;
            //return Convert.ToInt32(sq_com.ExecuteScalar());

            //if (dt.Rows.Count > 0)
            //{
            //    if (this.passward== dt.Rows[0][0].ToString())
            //    {
            //        return true;
            //    }
            //    else
            //        return false;
            //}
            //else
            //    return false;

        }
        public static void rdata()
        {

        }
    }
}