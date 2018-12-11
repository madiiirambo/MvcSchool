using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication19.Models
{
    public class login
    {
        public int uid { get; set; }
        public string passward { get; set; }

        public login(string passward)
        {

            
            this.passward = passward;
        }
        public int get_data(login l)
        {
            SqlCommand sq_com = new SqlCommand("login", Class1.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;

            sq_com.Parameters.AddWithValue("@passward", l.passward);
            //SqlDataAdapter sda = new SqlDataAdapter(sq_com);

            //DataTable dt = new DataTable();
            //sda.Fill(dt);
            return Convert.ToInt32(sq_com.ExecuteScalar());

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
    }
}