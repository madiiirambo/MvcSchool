using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class Get_Std_By_Class
    {
        [Required]
        [Display(Name = "Class No")]
        public string class_no { get; set; }

        [Required]
        [Display(Name = "Student ID")]
        public int std_id { get; set; }

        [Required]
        [Display(Name = "Student Name")]
        public string std_name { get; set; }

        [Required]
        [Display(Name = "Student Father Name")]
        public string std_f_name { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string std_gender { get; set; }

        

        public List<Get_Std_By_Class> get_std_by_class(string class_no)
        {
            List<Get_Std_By_Class> std_list = new List<Get_Std_By_Class>();

            SqlCommand sc = new SqlCommand("get_std_by_class", Connections.GetConnection());
            sc.Parameters.AddWithValue("@class_no", class_no);
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(sc);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Get_Std_By_Class sm = new Get_Std_By_Class();
                sm.std_id = Convert.ToInt32(dt.Rows[i][0]);
                sm.std_name = dt.Rows[i][1].ToString();
                sm.std_f_name = dt.Rows[i][2].ToString();
                sm.std_gender = dt.Rows[i][3].ToString();


                std_list.Add(sm);
            }
            return (std_list);
        }




        
    }
}