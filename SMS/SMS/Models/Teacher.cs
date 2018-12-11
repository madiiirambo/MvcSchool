using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class Teacher
    {
        [Required]
        [Display(Name = "Teacher ID")]
        public int t_id { get; set; }

        [Required]
        [Display(Name = "Teacher Name")]
        public string t_name { get; set; }

        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string t_pass { get; set; }

        [Required]
        [Display(Name = "Teacher Contact")]
        public string t_contact { get; set; }

        [Required]
        [Display(Name = "Teacher Address")]
        public string t_address { get; set; }

        [Required]
        [Display(Name = "Teacher Email")]
        public string t_email { get; set; }
        public void add_teacher()
        {

            SqlCommand sq_com = new SqlCommand("add_t_info", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;

            sq_com.Parameters.AddWithValue("@t_name", t_name);
            sq_com.Parameters.AddWithValue("@t_pass", t_pass);
            sq_com.Parameters.AddWithValue("@t_contact", t_contact);
            sq_com.Parameters.AddWithValue("@t_address", t_address);
            sq_com.Parameters.AddWithValue("@t_email", t_email);
            sq_com.ExecuteNonQuery();

        }
        public List<Teacher> get_all_t()
        {
            List<Teacher> teach = new List<Teacher>();

            SqlCommand sc = new SqlCommand("get_all_t", Connections.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sda = new SqlDataAdapter(sc);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Teacher sm = new Teacher();
                sm.t_id = Convert.ToInt32(dt.Rows[i][0]);
                sm.t_name = dt.Rows[i][1].ToString();
                sm.t_pass = dt.Rows[i][2].ToString();
                sm.t_contact = dt.Rows[i][3].ToString();
                sm.t_address = dt.Rows[i][4].ToString();
                sm.t_email = dt.Rows[i][5].ToString();
                

                teach.Add(sm);
            }
            return (teach);
        }


    }
}