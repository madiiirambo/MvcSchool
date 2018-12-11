using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication19.Models
{
    public class bookcopy
    {
        public int bcno { get; set; }
        public int isbn { get; set; }
        public int blid { get; set; }
        
        public static string bno="";
        public bookcopy(int bcno,int isbn,int blid)
        {

            this.bcno=bcno;
            this.isbn=isbn;
            this.blid=blid;
        
        }

        public static DataTable Select()
        {
            SqlCommand sc = new SqlCommand("bcselect", Class1.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            return dt;
        }
        public static void enter(bookcopy s)
        {
            SqlCommand sc = new SqlCommand("bookcopyenter", Class1.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@bcno", s.bcno);

            sc.Parameters.AddWithValue("@isbn", s.isbn);
            sc.Parameters.AddWithValue("@blid", s.blid);

            sc.ExecuteNonQuery();
        }

        public static DataTable fk()
        {
            
            SqlCommand sc = new SqlCommand("select Bcopyno from BookRecv except select Bcopyno from BookCopy", Class1.GetConnection());
            //sc.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            return dt;

        }
        //public static DataTable fkbino()
        //{
            
        //    SqlCommand sc = new SqlCommand("select Bissueno from BookRecv except select Bisueno from BookCopy", Class1.GetConnection());
        //    //sc.CommandType = CommandType.StoredProcedure;
        //    SqlDataAdapter sda = new SqlDataAdapter(sc);
        //    DataTable dt = new DataTable();

        //    sda.Fill(dt);
        //    return dt;

        //}

        public static DataTable update()
        {
            //string id="";
            //id = id;
            SqlCommand sc = new SqlCommand("select * from BookCopy  where Bcopyno='" + bno + "'", Class1.GetConnection());
            //sc.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            return dt;

        }
        
        public static void update(bookcopy s)
        {
            SqlCommand sc = new SqlCommand("bookcopyedit", Class1.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@bcno", s.bcno);

            sc.Parameters.AddWithValue("@isbn", s.isbn);
            sc.Parameters.AddWithValue("@blid", s.blid);

            sc.ExecuteNonQuery();
        }
    }
}