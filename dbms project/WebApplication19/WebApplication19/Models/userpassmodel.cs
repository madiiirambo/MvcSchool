using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace WebApplication19.Models
{
    public class userpassmodel
    {
        public int Userid { get; set; }
        public string pass { get; set; }

        public userpassmodel(int mid,string pass)
        {
            this.Userid = mid;
            this.pass = pass;

        }
        public static void ps(userpassmodel s)
        {
            SqlCommand sc = new SqlCommand("userr", Class1.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@Userid", s.Userid);

            sc.Parameters.AddWithValue("@password", s.pass);


            sc.ExecuteNonQuery();
        }
        public static DataTable Select()
        {
            SqlCommand sc = new SqlCommand("selectmember", Class1.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            return dt;
        }
        public static string id="";

        public static void edit1(userpassmodel s)
        {
            SqlCommand sc = new SqlCommand("passwardupdate", Class1.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@mid", s.Userid);

            sc.Parameters.AddWithValue("@pass", s.pass);


            sc.ExecuteNonQuery();
        }
        public static DataTable edit()
        {
            //string id="";
            //id = id;
            SqlCommand sc = new SqlCommand("select * from Useracc  where Userid='" + id + "'", Class1.GetConnection());
            //sc.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            return dt;

        }
        public static DataTable fk()
        {
            //string id="";
            //id = id;
            SqlCommand sc = new SqlCommand("select Mid from Member except select Userid from Useracc", Class1.GetConnection());
            //sc.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            return dt;

        }
    }
}