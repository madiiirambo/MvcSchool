using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication19.Models
{
    public class bookmodel
    {
        public int bkid { get; set; }
        public string title { get; set; }
        public static string bid = "";
        public bookmodel(int bkid,string title)
            
        {
            this.bkid = bkid;
            this.title = title;

        }
        public static DataTable Select()
        {
            SqlCommand sc = new SqlCommand("bookselect", Class1.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            return dt;
        }
        public static void enter(bookmodel s)
        {
            SqlCommand sc = new SqlCommand("bookenter", Class1.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@bkid", s.bkid);

            sc.Parameters.AddWithValue("@title", s.title);
            
            sc.ExecuteNonQuery();
        }
        public static DataTable fk()
        {

            SqlCommand sc = new SqlCommand("select Bookid from Location except select Bid from Bok", Class1.GetConnection());
            //sc.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            return dt;

        }
        public static DataTable update()
        {
            //string id="";
            //id = id;
            SqlCommand sc = new SqlCommand("select * from Bok  where Bid='" + bid + "'", Class1.GetConnection());
            //sc.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            return dt;

        }

        public static void update(bookmodel s)
        {
            SqlCommand sc = new SqlCommand("bookedit", Class1.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@bkid", s.bkid);

            sc.Parameters.AddWithValue("@title", s.title);
           

            sc.ExecuteNonQuery();
        }
    }
}