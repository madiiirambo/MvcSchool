using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication19.Models
{
    public class publishermodel
    {
        public int pid { get; set; }
        public string pname { get; set; }
        public static string id = "";
        public publishermodel(int pid,string pname)
         
            {
                this.pid = pid;
                this.pname = pname;
            }
        public static DataTable Select()
        {
            SqlCommand sc = new SqlCommand("publisherselect", Class1.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            return dt;
        }
        public static void enter(publishermodel s)
        {
            SqlCommand sc = new SqlCommand("publisherenter", Class1.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@pid", s.pid);

            sc.Parameters.AddWithValue("@pname", s.pname);
            
            sc.ExecuteNonQuery();
        }
        public static DataTable fk()
        {

            SqlCommand sc = new SqlCommand("select Publishid from BookEdition except select Pid from Publisher", Class1.GetConnection());

            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            return dt;

        }
        public static DataTable update()
        {


            SqlCommand sc = new SqlCommand("select * from Publisher  where Pid='" + id + "'", Class1.GetConnection());

            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            return dt;

        }
        public static void update(publishermodel s)
        {
            SqlCommand sc = new SqlCommand("publisheredit", Class1.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@pid", s.pid);

            sc.Parameters.AddWithValue("@pname", s.pname);
            

            sc.ExecuteNonQuery();
        }

    }
}