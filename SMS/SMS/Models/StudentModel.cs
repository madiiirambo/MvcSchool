using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class StudentModel
    {

        [Required]
        [Display(Name = "Student ID")]
        public int std_id { get; set; }

        [Required]
        [Display(Name = "Student Name")]
        public string std_name { get; set; }

        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string std_pass { get; set; }

        [Required]
        [Display(Name = "Student Father Name")]
        public string std_f_name { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string std_gender { get; set; }


        [Required]
        [Display(Name = "Age")]
        public string std_age { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        public string std_Dob { get; set; }

        [Required]
        [Display(Name = "Contact")]
        public string std_contact { get; set; }

        [Required]
        [Display(Name = "Father Contact")]
        public string std_f_contact { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string std_address { get; set; }


        public void addstd_data()
        {

            SqlCommand sq_com = new SqlCommand("add_std_info", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;

            sq_com.Parameters.AddWithValue("@std_name", std_name);
            sq_com.Parameters.AddWithValue("@std_pass", std_pass);
            sq_com.Parameters.AddWithValue("@std_fname", std_f_name);
            sq_com.Parameters.AddWithValue("@std_gender", std_gender);
            sq_com.Parameters.AddWithValue("@std_age", std_age);
            sq_com.Parameters.AddWithValue("@std_dob", std_Dob);
            sq_com.Parameters.AddWithValue("@std_contact", std_contact);
            sq_com.Parameters.AddWithValue("@std_f_contact", std_f_contact);
            sq_com.Parameters.AddWithValue("@std_address", std_address);

            sq_com.ExecuteNonQuery();

        }
        public bool Get_std_data(int std_id)
        {
            SqlCommand sq_com = new SqlCommand("get_std", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;

            sq_com.Parameters.AddWithValue("@std_id", std_id);
            SqlDataAdapter sda = new SqlDataAdapter(sq_com);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                std_id = Convert.ToInt32(dt.Rows[0][0]);
                std_name = dt.Rows[0][1].ToString();
                std_pass = dt.Rows[0][2].ToString();
                std_f_name = dt.Rows[0][3].ToString();
                std_gender = dt.Rows[0][4].ToString();
                std_age = dt.Rows[0][5].ToString();
                std_Dob = dt.Rows[0][6].ToString();
                std_contact = dt.Rows[0][7].ToString();
                std_f_contact = dt.Rows[0][8].ToString();
                std_address = dt.Rows[0][9].ToString();

                return true;
            }
            else
                return false;
        }
        public List<StudentModel> get_all_std()
        {

            List<StudentModel> std_list = new List<StudentModel>();

            SqlCommand sc = new SqlCommand("get_all_std", Connections.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sda = new SqlDataAdapter(sc);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                StudentModel sm = new StudentModel();
                sm.std_id = Convert.ToInt32(dt.Rows[i][0]);
                sm.std_name = dt.Rows[i][1].ToString();
                sm.std_pass = dt.Rows[i][2].ToString();
                sm.std_f_name = dt.Rows[i][3].ToString();
                sm.std_gender = dt.Rows[i][4].ToString();
                sm.std_age = dt.Rows[i][5].ToString();
                sm.std_Dob = dt.Rows[i][6].ToString();
                sm.std_contact = dt.Rows[i][7].ToString();
                sm.std_f_contact = dt.Rows[i][8].ToString();
                sm.std_address = dt.Rows[i][9].ToString();




                std_list.Add(sm);
            }
            return (std_list);
        }

        public void std_upt()
        {
            SqlCommand sq_com = new SqlCommand("std_update", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;
            sq_com.Parameters.AddWithValue("@std_id", std_id);
            sq_com.Parameters.AddWithValue("@std_name", std_name);
            sq_com.Parameters.AddWithValue("@std_pass", std_pass);
            sq_com.Parameters.AddWithValue("@std_fname", std_f_name);
            sq_com.Parameters.AddWithValue("@std_gender", std_gender);
            sq_com.Parameters.AddWithValue("@std_age", std_age);
            sq_com.Parameters.AddWithValue("@std_dob", std_Dob);
            sq_com.Parameters.AddWithValue("@std_contact", std_contact);
            sq_com.Parameters.AddWithValue("@std_f_contact", std_f_contact);
            sq_com.Parameters.AddWithValue("@std_address", std_address);

            sq_com.ExecuteNonQuery();
        }

        public void std_delete()
        {
            SqlCommand sq_com = new SqlCommand("std_delete", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;
            sq_com.Parameters.AddWithValue("@std_id", std_id);
            

            sq_com.ExecuteNonQuery();


        }
    }
}