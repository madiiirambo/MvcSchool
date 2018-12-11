using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication19.Models
{
    public class author
    {
        public int aid { get; set; }
        public string aname { get; set; }
        public static string id = "";
        public author(int aid,string aname)
        {

            this.aid = aid;
            this.aname = aname;
        }
        public static DataTable Select()
        {
            SqlCommand sc = new SqlCommand("authorselect", Class1.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            return dt;
        }
        public static void enter(author s)
        {
            SqlCommand sc = new SqlCommand("authorenter", Class1.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            

            sc.Parameters.AddWithValue("@aid", s.aid);
            sc.Parameters.AddWithValue("@aname", s.aname);


            sc.ExecuteNonQuery();
        }
        public static DataTable fk()
        {

            SqlCommand sc = new SqlCommand("select Aid from BookAuthor except select Aid from Author", Class1.GetConnection());
            //sc.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            return dt;

        }
        public static DataTable update()
        {
           
            SqlCommand sc = new SqlCommand("select * from Author  where Aid='" + id + "'", Class1.GetConnection());
            
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            return dt;

        }

        public static void update(author s)
        {
            SqlCommand sc = new SqlCommand("authoredit", Class1.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
           

            sc.Parameters.AddWithValue("@aid", s.aid);
            sc.Parameters.AddWithValue("@aname", s.aname);

            sc.ExecuteNonQuery();
        }
    }
}