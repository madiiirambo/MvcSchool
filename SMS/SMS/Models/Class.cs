using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class Class
    {
        [Required]
        [Display(Name = "Class ID")]
        public int class_id { get; set; }

        [Required]
        [Display(Name = "Subjct ID")]
        public int sub_id { get; set; }

        [Required]
        [Display(Name = "Teacher ID")]
        public int t_id { get; set; }


        [Required]
        [Display(Name = "Class No")]
        public string class_no { get; set; }

        [Required]
        [Display(Name = "Section ")]
        public string section { get; set; }

        [Required]
        [Display(Name = "Fix Year Id")]
        public int fix_year_id { get; set; }

        [Required]
        [Display(Name = "Room No")]
        public int room_no { get; set; }

        public void add_class()
        {

            SqlCommand sq_com = new SqlCommand("add_class", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;

            sq_com.Parameters.AddWithValue("@class_no", class_no);
            sq_com.Parameters.AddWithValue("@section", section);
            sq_com.Parameters.AddWithValue("@fix_year_id", fix_year_id);
            sq_com.Parameters.AddWithValue("@room_no", room_no);
            sq_com.ExecuteNonQuery();

        }

        public void add_class_sub()
        {
            SqlCommand sq_com = new SqlCommand("add_class_sub", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;

            sq_com.Parameters.AddWithValue("@class_id", class_id);
            sq_com.Parameters.AddWithValue("@sub_id", sub_id);
            sq_com.Parameters.AddWithValue("@t_id", t_id);
            sq_com.ExecuteNonQuery();
        }


        public List<Class> get_class_all_id_()
        {
            List<Class> pro_list = new List<Class>();

            SqlCommand sc = new SqlCommand("get_class_ids", Connections.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;

            SqlDataReader sdr = sc.ExecuteReader();

            while (sdr.Read())
            {
                Class prog = new Class();
                prog.class_id = Convert.ToInt32(sdr["class_id"]);


                pro_list.Add(prog);
            }

            sdr.Close();
            return (pro_list);


        }
        public List<Class> get_sub_all_id_()
        {
            List<Class> pro_list = new List<Class>();

            SqlCommand sc = new SqlCommand("get_subject_ids", Connections.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;

            SqlDataReader sdr = sc.ExecuteReader();

            while (sdr.Read())
            {
                Class prog = new Class();
                prog.sub_id = Convert.ToInt32(sdr["sub_id"]);


                pro_list.Add(prog);
            }

            sdr.Close();
            return (pro_list);

        }
        public List<Class> get_sub_t_id_()
        {
            List<Class> pro_list = new List<Class>();

            SqlCommand sc = new SqlCommand("get_all_t_ids", Connections.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;

            SqlDataReader sdr = sc.ExecuteReader();

            while (sdr.Read())
            {
                Class prog = new Class();
                prog.t_id = Convert.ToInt32(sdr["t_id"]);


                pro_list.Add(prog);
            }

            sdr.Close();
            return (pro_list);

        }
    }
}