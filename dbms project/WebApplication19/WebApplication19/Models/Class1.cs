using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
namespace WebApplication19.Models
{
    public class Class1
    {
        private static SqlConnection SqlConnection;

        public static SqlConnection GetConnection()
        {
            //if (SqlConnection == null)
            //{
            //    SqlConnection = new SqlConnection();
            //    SqlConnection = new SqlConnection(@"Data Source=.\;Initial Catalog = library;Integrated Security = SSPI");
            //    SqlConnection.Open();
            //}
            if (SqlConnection == null)
            {
                SqlConnection = new SqlConnection();
                SqlConnection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog = library;Integrated Security = SSPI");
                SqlConnection.Open();
            }
            return SqlConnection;
        }
        }
    }
//if (My_SQL_Connection == null)
//            {
//                My_SQL_Connection = new SqlConnection();
//                My_SQL_Connection.ConnectionString = ConfigurationManager.ConnectionStrings["LMS"].ToString();
//                My_SQL_Connection.Open();
//            }
//            return My_SQL_Connection;