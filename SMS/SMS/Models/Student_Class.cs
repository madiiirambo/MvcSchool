using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Models
{
    public class Student_Class
    {
        [Required]
        [Display(Name = "Student ID")]
        public int std_id { get; set; }

        [Required]
        [Display(Name = "Class ID")]
        public string class_id { get; set; }

        [Required]
        [Display(Name = "Reg Date ")]
        public string reg_date { get; set; }

        

        public void add_std_class()
        {

            SqlCommand sq_com = new SqlCommand("add_std_class", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;

            sq_com.Parameters.AddWithValue("@std_id", std_id);
            sq_com.Parameters.AddWithValue("@class_id", class_id);
            sq_com.Parameters.AddWithValue("@reg_date", reg_date);
            sq_com.ExecuteNonQuery();

        }

        public List<Student_Class> get_std_all_ids()
        {
            List<Student_Class> pro_list = new List<Student_Class>();

            SqlCommand sc = new SqlCommand("get_all_std_ids", Connections.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;

            SqlDataReader sdr = sc.ExecuteReader();

            while (sdr.Read())
            {
                Student_Class prog = new Student_Class();
                prog.std_id = Convert.ToInt32(sdr["std_id"]);


                pro_list.Add(prog);
            }

            sdr.Close();
            return (pro_list);
        }
        
    }
}