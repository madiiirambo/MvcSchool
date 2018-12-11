using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication19.Models
{
    public class member
    {
        public string name { get; set; }
        public string email { get; set; }
        public string contact { get; set; }
        public string addr { get; set; }
        public string cnic { get; set; }
        public int mid { get; set; }

        public static DataTable fk()
        {

            SqlCommand sc = new SqlCommand("select Mid from Member ", Class1.GetConnection());

            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            return dt;

        }
    }
}