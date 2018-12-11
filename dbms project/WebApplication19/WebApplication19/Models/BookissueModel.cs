using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace WebApplication19.Models
{
    public class BookissueModel
    {
        [Required]
        [Display(Name="Book Issue No.")]
        public int bisno { get; set; }
        [Required]
        [Display(Name="Book Issue Date")]

        public string bisdate { get; set; }
        [Required]
        [Display(Name="Member Id")]

        public int mid { get; set; }
        [Required]
       [Display(Name="Due Date")] 
        public string dda { get; set; }

        public static DataTable booku()
        {
            SqlCommand sc = new SqlCommand("bu", Class1.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
    }
}