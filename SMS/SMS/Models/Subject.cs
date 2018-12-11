using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class Subject
    {
        [Required]
        [Display(Name = "Subject Id")]
        public int sub_id { get; set; }

        [Required]
        [Display(Name = "Subject Name")]
        public string sub_name { get; set; }

        public void add_sub()
        {

            SqlCommand sq_com = new SqlCommand("add_sub", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;

            sq_com.Parameters.AddWithValue("@sub_name", sub_name);
            
            sq_com.ExecuteNonQuery();

        }


    }
}