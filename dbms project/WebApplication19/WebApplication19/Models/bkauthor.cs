using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication19.Models
{
    public class bkauthor
    {
        public int isbn { get; set; }
        public int aid { get; set; }
        public string aname { get; set; }
        public static string id = "";
        public bkauthor(int isbn,int aid,string aname)
        {

            this.isbn = isbn;
            this.aid = aid;
            this.aname = aname;
        }
        public static DataTable Select()
        {
            SqlCommand sc = new SqlCommand("bkauthorselect", Class1.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            return dt;
        }
        public static void enter(bkauthor s)
        {
            SqlCommand sc = new SqlCommand("bkauthorenter", Class1.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@isbn", s.isbn);

            sc.Parameters.AddWithValue("@aid", s.aid);
            sc.Parameters.AddWithValue("@aname", s.aname);

           
            sc.ExecuteNonQuery();
        }
        public static DataTable fk()
        {

            SqlCommand sc = new SqlCommand("select ISBN from BookCopy except select ISBN from BookAuthor", Class1.GetConnection());
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
            SqlCommand sc = new SqlCommand("select * from BookAuthor  where ISBN='" + id + "'", Class1.GetConnection());
            //sc.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            return dt;

        }

        public static void update(bkauthor s)
        {
            SqlCommand sc = new SqlCommand("bkauthoredit", Class1.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
           
            sc.Parameters.AddWithValue("@isbn", s.isbn);

            sc.Parameters.AddWithValue("@aid", s.aid);
            sc.Parameters.AddWithValue("@aname", s.aname);

            sc.ExecuteNonQuery();
        }
    }
}