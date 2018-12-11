using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication19.Models
{
    public class locationmodel
    {
        public int locid { get; set; }
        public int shelfno { get; set; }
        public static string lid = "";

        public locationmodel(int locid,int shelfno)
        {

            this.locid = locid;
            this.shelfno = shelfno;
        }
        public static DataTable Select()
        {
            SqlCommand sc = new SqlCommand("locselect", Class1.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            return dt;
        }
        public static DataTable fk()
        {

            SqlCommand sc = new SqlCommand("select Locid from BookCopy except select Locationid from Location", Class1.GetConnection());

            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            return dt;

        }
        public static void enter(locationmodel s)
        {
            SqlCommand sc = new SqlCommand("locenter", Class1.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@locid", s.locid);

            sc.Parameters.AddWithValue("@shelfno", s.shelfno);
            
            sc.ExecuteNonQuery();
        }
        public static DataTable edit()
        {
            //string id="";
            //id = id;
            SqlCommand sc = new SqlCommand("select * from Location  where Locationid='" + lid + "'", Class1.GetConnection());
            //sc.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            return dt;

        }
        public static void edit(locationmodel s)
        {
            SqlCommand sc = new SqlCommand("locedit", Class1.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@locid", s.locid);

            sc.Parameters.AddWithValue("@shelfno", s.shelfno);
            
            sc.ExecuteNonQuery();
        }
    }
}