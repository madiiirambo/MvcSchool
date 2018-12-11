using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication19.Models
{
    public class bookrecvmodel
    {
        public int bissueno { get; set; }
        
        public int bcopyno { get; set; }
        public DateTime date { get; set; }
        public int fine { get; set; }
        public static string bino="";
        public bookrecvmodel(int bissueno,int bcopyno,DateTime date,int fine)
        {

            this.bissueno = bissueno;
            this.bcopyno = bcopyno;
            this.date = date;
            this.fine = fine;
        }
        public static DataTable Select()
        {
            SqlCommand sc = new SqlCommand("bokrecv", Class1.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            return dt;
        }
        public static void enter(bookrecvmodel s)
        {
            SqlCommand sc = new SqlCommand("bookrecventer", Class1.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@bookisno", s.bissueno);

            sc.Parameters.AddWithValue("@bcno", s.bcopyno);
            sc.Parameters.AddWithValue("@brd", s.date);
            sc.Parameters.AddWithValue("@fine", s.fine);
            sc.ExecuteNonQuery();
        }

        public static DataTable fk()
        {
            //string id="";
            //id = id;
            SqlCommand sc = new SqlCommand("select Bisuueno from BokIssue ", Class1.GetConnection());
            //sc.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            return dt;

        }
        public static DataTable edit()
        {
            //string id="";
            //id = id;
            SqlCommand sc = new SqlCommand("select * from BookRecv  where Bissueno='" + bino + "'", Class1.GetConnection());
            //sc.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            return dt;

        }
        public static void edit(bookrecvmodel s)
        {
            SqlCommand sc = new SqlCommand("bookrecvedit", Class1.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@bookisno", s.bissueno);

            sc.Parameters.AddWithValue("@bcno", s.bcopyno);
            sc.Parameters.AddWithValue("@brd", s.date);
            sc.Parameters.AddWithValue("@fine", s.fine);
            sc.ExecuteNonQuery();
        }
        
    }
}