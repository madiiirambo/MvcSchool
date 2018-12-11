using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "User Name")]
        public string U_name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string U_pass { get; set; }
        public int AdminLogin()
        {


            SqlCommand sq_com = new SqlCommand("ad_login", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;
            sq_com.Parameters.AddWithValue("@U_name", U_name);
            SqlDataAdapter sda = new SqlDataAdapter(sq_com);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
                if (dt.Rows[0][0].Equals(U_pass))
                {
                    return 1;
                }
            return -1;



        }
    }

}