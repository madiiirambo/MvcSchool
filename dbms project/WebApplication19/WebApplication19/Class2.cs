using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication19
{
    public  class Class2
    {
        public static void asd(Models.newmem w)
        {

            SqlCommand sc = new SqlCommand("upd", Class1.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@mid", w.midd);
            
            sc.Parameters.AddWithValue("@name", w.name);
            sc.Parameters.AddWithValue("@email", w.email);
            sc.Parameters.AddWithValue("@contact", w.contact);
            sc.Parameters.AddWithValue("@address", w.addr);
            sc.Parameters.AddWithValue("@cnic", w.cnic);

            sc.ExecuteNonQuery();
            //SqlDataReader dr = sc.ExecuteReader();
            //var model = new List<Models.newmem>();

            //while (dr.Read())
            //{
            //    var m = new Models.newmem();
                
            //    m.name=dr[""].ToString();
            //    m.email = dr[""].ToString();
            //    m.contact = dr[""].ToString();
            //    m.addr = dr[""].ToString();
            //    m.cnic = dr[""].ToString();
            //    model.Add(m);
                //TextBox1.Text = dr["username"].ToString();

                //TextBox2.Text = dr["password"].ToString();

                //TextBox3.Text = dr["fname"].ToString();

                //TextBox4.Text = dr["gender"].ToString();

            }
        public static void ps(Models.User s)
        {
            SqlCommand sc = new SqlCommand("userr", Class1.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@Userid", s.Userid);

            sc.Parameters.AddWithValue("@password", s.passward);


            //    public static void ps(Models.newmem s)
            //{
            //    SqlCommand sc = new SqlCommand("ps", Class1.GetConnection());
            //    sc.CommandType = CommandType.StoredProcedure;
            //    sc.Parameters.AddWithValue("@mid", s.mid);

            //    sc.Parameters.AddWithValue("@pswd", s.pswd);

            //}
            sc.ExecuteNonQuery();
        }
        public static DataTable Select()
        {
            SqlCommand sc = new SqlCommand("SelectPeople", Class1.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            return dt;
        }
        public static DataTable booku()
        {
            SqlCommand sc = new SqlCommand("bu", Class1.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public static string id="";
        public static  DataTable upmg()
        {
            //string id="";
            //id = id;
            SqlCommand sc = new SqlCommand("select * from Member except select Mid from BokIssue  where Mid='" + id + "'", Class1.GetConnection());
            //sc.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            return dt;

        }
        public static void bk(Models.newmem a)
        {

            SqlCommand sc = new SqlCommand("BokIssu", Class1.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@bisno", a.bisno);
            sc.Parameters.AddWithValue("@bisdate", a.bisdate);
            sc.Parameters.AddWithValue("@mid", a.mid);
            sc.Parameters.AddWithValue("@ddate", a.dda);
           
            
            sc.ExecuteNonQuery();
        }
        public static void bku(Models.newmem a)
        {

            SqlCommand sc = new SqlCommand("bku", Class1.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@bisno", a.bisno);
            sc.Parameters.AddWithValue("@bisdate", a.bisdate);
            sc.Parameters.AddWithValue("@mid", a.mid);
            sc.Parameters.AddWithValue("@ddate", a.dda);


            sc.ExecuteNonQuery();
        }


        public static void newme(Models.newmem a)
        {

            SqlCommand sc = new SqlCommand("newmember", Class1.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@name", a.name);
            sc.Parameters.AddWithValue("@email", a.email);
            sc.Parameters.AddWithValue("@contact", a.contact);
            sc.Parameters.AddWithValue("@address", a.addr);
            sc.Parameters.AddWithValue("@cnic", a.cnic);
            sc.ExecuteNonQuery();
        }
    }
}