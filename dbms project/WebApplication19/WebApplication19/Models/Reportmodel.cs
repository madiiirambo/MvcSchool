using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication19.Models
{
    public class Reportmodel
    {
        public int Mid { get; set; }
        public string Mname { get; set; }
        public string Memail { get; set; }
        public string Mcontact { get; set; }
        public string Maddress { get; set; }
        public string CNIC { get; set; }
        public static List<Reportmodel> get_report_data()
        {
            List<Reportmodel> rm_list = new List<Reportmodel>();

            SqlCommand sc = new SqlCommand("get_report_data", Class1.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;

            SqlDataReader sdr = sc.ExecuteReader();

            while (sdr.Read())
            {
                Reportmodel rm = new Reportmodel();
                rm.Mid = Convert.ToInt32(sdr["Mid"]);
                rm.Mname = sdr["Mname"].ToString();
                rm.Memail = sdr["Memail"].ToString();
                rm.Mcontact = sdr["Mcontact"].ToString();
                rm.Maddress = sdr["Maddress"].ToString();
                rm.CNIC = sdr["CNIC"].ToString();
                rm_list.Add(rm);
            }

            sdr.Close();
            return (rm_list);
        }
    }
}