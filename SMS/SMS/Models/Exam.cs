using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class Exam
    {
        [Required]
        [Display(Name = "Exam ID")]
        public int exam_id { get; set; }

        [Required]
        [Display(Name = "Exam Tittle")]
        public string exam_tittle { get; set; }

        [Required]
        [Display(Name = "Exam Date ")]
        public string exam_date { get; set; }

        [Required]
        [Display(Name = "Max Marks")]
        public string max_marks { get; set; }

        public void add_exam()
        {

            SqlCommand sq_com = new SqlCommand("add_exam", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;

            sq_com.Parameters.AddWithValue("@exam_tittle", exam_tittle);
            sq_com.Parameters.AddWithValue("@exam_date", exam_date);
            sq_com.Parameters.AddWithValue("@max_marks", max_marks);
            sq_com.ExecuteNonQuery();

        }
    }
}