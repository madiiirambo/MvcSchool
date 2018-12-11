using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication19.Models
{
    public class bkeditionn
    {
        public int bkid { get; set; }
        public string bkedition { get; set; }
        public int pid { get; set; }
        public DateTime pdate { get; set; }
        public static string bid = "";
        public bkeditionn(int bkid,string bkedition,int pid,DateTime pdate)
        {
            this.bkid = bkid;
            this.bkedition = bkedition;
            this.pid = pid;
            this.pdate = pdate;

        }
        public static DataTable Select()
        {
            SqlCommand sc = new SqlCommand("beditionselect", Class1.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            return dt;
        }
        public static void enter(bkeditionn s)
        {
            SqlCommand sc = new SqlCommand("beditionenter", Class1.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@bkid", s.bkid);

            sc.Parameters.AddWithValue("@bkedition", s.bkedition);
            sc.Parameters.AddWithValue("@pid", s.pid);

            sc.Parameters.AddWithValue("@pdate", s.pdate);
            sc.ExecuteNonQuery();
        }
        public static DataTable fk()
        {

            SqlCommand sc = new SqlCommand("select Bid from Bok except select Bid from BookEdition", Class1.GetConnection());
            
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            return dt;

        }
        public static DataTable update()
        {
            
            
            SqlCommand sc = new SqlCommand("select * from BookEdition  where Bid='" + bid + "'", Class1.GetConnection());
            
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            return dt;

        }

        public static void update(bkeditionn s)
        {
            SqlCommand sc = new SqlCommand("beditionedit", Class1.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@bkid", s.bkid);

            sc.Parameters.AddWithValue("@bkedition", s.bkedition);
            sc.Parameters.AddWithValue("@pid", s.pid);

            sc.Parameters.AddWithValue("@pdate", s.pdate);

            sc.ExecuteNonQuery();
        }
    }
}