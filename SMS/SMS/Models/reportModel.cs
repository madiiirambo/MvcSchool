using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class reportModel
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

        public static List<reportModel> get_report_data()
        {
            List<reportModel> rm_list = new List<reportModel>();

            SqlCommand sc = new SqlCommand("get_all_std", Connections.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;

            SqlDataReader sdr = sc.ExecuteReader();

            while (sdr.Read())
            {
                reportModel rm = new reportModel();
                rm.std_id = Convert.ToInt32(sdr["std_id"]);
                rm.std_name = sdr["std_name"].ToString();
                rm.std_pass = sdr["std_pass"].ToString();
                rm.std_f_name = sdr["std_fname"].ToString();
                rm.std_gender = sdr["std_gender"].ToString();
                rm.std_age = sdr["std_age"].ToString();
                rm.std_Dob = sdr["std_Dob"].ToString();
                rm.std_contact = sdr["std_contact"].ToString();
                rm.std_f_contact = sdr["std_f_contact"].ToString();
                rm.std_address = sdr["std_address"].ToString();

                rm_list.Add(rm);
            }

            sdr.Close();
            return (rm_list);
        }
    }
}