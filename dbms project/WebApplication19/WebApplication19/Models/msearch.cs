using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication19.Models
{
    public class msearch
    {
        public static int id { get; set; }
        //public msearch(int id)
        //{
        //    this.id = id;
        //}
        public static DataTable search()
        {
            string Sqry = "select * from Member  where Mid='" + id + "'";
            SqlCommand sqlcmd = new SqlCommand(Sqry, Class1.GetConnection());
            SqlDataAdapter sda = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        
    }
}