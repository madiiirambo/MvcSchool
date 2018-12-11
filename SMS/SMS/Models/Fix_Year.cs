using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class Fix_Year
    {
        [Required]
        [Display(Name = "Fix Year ID")]
        public int fix_year_id { get; set; }

        [Required]
        [Display(Name = "Starting Date")]
        public string s_date { get; set; }

        [Required]
        [Display(Name = "Ending Date")]
        public string e_date { get; set; }


        public void add_fix_year()
        {

            SqlCommand sq_com = new SqlCommand("add_fix_year", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;

            sq_com.Parameters.AddWithValue("@s_date", s_date);
            sq_com.Parameters.AddWithValue("@e_date", e_date);

            sq_com.ExecuteNonQuery();

        }
    }
}