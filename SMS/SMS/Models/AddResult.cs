using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class AddResult
    {

        [Required]
        [Display(Name = "Attendence Date")]
        public string atten_date { get; set; }


        [Required]
        [Display(Name = "Student ID")]
        public int std_id { get; set; }

        [Required]
        [Display(Name = "Student Name")]
        public string std_name { get; set; }


        [Required]
        [Display(Name = "Class ID")]
        public int class_id { get; set; }

        [Required]
        [Display(Name = "Subject ID")]
        public int sub_id { get; set; }

        [Required]
        [Display(Name = "Exam ID")]
        public int exam_id { get; set; }

        [Required]
        [Display(Name = "Marks Obtained")]
        public string marks_obt { get; set; }


        [Required]
        [Display(Name = "P or A")]
        public string p_or_a { get; set; }

        public List<AddResult> get_std_all_id_()
        {
            List<AddResult> pro_list = new List<AddResult>();

            SqlCommand sc = new SqlCommand("get_std_idss", Connections.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;

            SqlDataReader sdr = sc.ExecuteReader();

            while (sdr.Read())
            {
                AddResult prog = new AddResult();
                prog.std_id = Convert.ToInt32(sdr["std_id"]);


                pro_list.Add(prog);
            }

            sdr.Close();
            return (pro_list);

        }
        public List<AddResult> get_class_all_id_()
        {
            List<AddResult> pro_list = new List<AddResult>();

            SqlCommand sc = new SqlCommand("get_class_ids", Connections.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;

            SqlDataReader sdr = sc.ExecuteReader();

            while (sdr.Read())
            {
                AddResult prog = new AddResult();
                prog.class_id = Convert.ToInt32(sdr["class_id"]);


                pro_list.Add(prog);
            }

            sdr.Close();
            return (pro_list);

        }
        public List<AddResult> get_exam_all_id_()
        {
            List<AddResult> pro_list = new List<AddResult>();

            SqlCommand sc = new SqlCommand("get_all_exam_ids", Connections.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;

            SqlDataReader sdr = sc.ExecuteReader();

            while (sdr.Read())
            {
                AddResult prog = new AddResult();
                prog.exam_id = Convert.ToInt32(sdr["exam_id"]);


                pro_list.Add(prog);
            }

            sdr.Close();
            return (pro_list);

        }
        public List<AddResult> get_sub_all_id_()
        {
            List<AddResult> pro_list = new List<AddResult>();

            SqlCommand sc = new SqlCommand("get_subject_ids", Connections.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;

            SqlDataReader sdr = sc.ExecuteReader();

            while (sdr.Read())
            {
                AddResult prog = new AddResult();
                prog.sub_id = Convert.ToInt32(sdr["sub_id"]);


                pro_list.Add(prog);
            }

            sdr.Close();
            return (pro_list);

        }
        public  List<AddResult> obj = new List<AddResult>();
        public bool add_result1(int class_id,int sub_id)
        {
            SqlCommand sq_com = new SqlCommand("show_res", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;

            sq_com.Parameters.AddWithValue("@class_id", class_id);
            sq_com.Parameters.AddWithValue("@sub_id", sub_id);
            SqlDataAdapter sda = new SqlDataAdapter(sq_com);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    obj.Add(new AddResult()
                    {
                        class_id = Convert.ToInt32(dt.Rows[i][0]),
                        sub_id = Convert.ToInt32(dt.Rows[i][1]),
                        std_id = Convert.ToInt32(dt.Rows[i][2]),
                        std_name = dt.Rows[i][3].ToString(),
                         
                        
                    });
                }
               
                
                
                return true;
            }
            else
                return false;
        }
        public void add_result(string std_id,string class_id,string exam_id,string sub_id,string marks_obt)
        {

            SqlCommand sq_com = new SqlCommand("add_result", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;

            sq_com.Parameters.AddWithValue("@std_id", int.Parse(std_id));
            sq_com.Parameters.AddWithValue("@class_id", int.Parse(class_id));
            sq_com.Parameters.AddWithValue("@exam_id", int.Parse(exam_id));
            sq_com.Parameters.AddWithValue("@sub_id", int.Parse(sub_id));
            sq_com.Parameters.AddWithValue("@marks_obt", (int.Parse(marks_obt)));
            sq_com.ExecuteNonQuery();
            // ye batao jab data return hota hai tw  kahan store hota hai stored procedure k thru?
            //is k upper ha method reuslt1
            // chlra hai?
            //  loop lagaoge error ah rhaa h tumhe single element ka kaam hai tw loop q ?
            // /single model se khelo :p ni yarr mujhe id dai kar sub sudnt ko table mai dalna h 
            // joo uss class mai hoo
        }

        public void add_attend()
        {

            SqlCommand sq_com = new SqlCommand("add_addendence", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;

            sq_com.Parameters.AddWithValue("@attend_date", atten_date);
            sq_com.Parameters.AddWithValue("@class_id", class_id);
            sq_com.Parameters.AddWithValue("@sub_id", std_id);
            sq_com.Parameters.AddWithValue("@std_id", sub_id);
            sq_com.Parameters.AddWithValue("@p_or_a", p_or_a);
            sq_com.ExecuteNonQuery();


        }

        
    }
}