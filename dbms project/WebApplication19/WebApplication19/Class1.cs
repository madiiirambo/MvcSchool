using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication19
{
    public class Class1
    {
        private static SqlConnection SqlConnection;

        public static SqlConnection GetConnection()
        {
            if (SqlConnection == null)
            {
                SqlConnection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog = library;Integrated Security = SSPI");
                SqlConnection.Open();
                //SqlConnection = new SqlConnection(@"Data Source=.\;Initial Catalog = library;Integrated Security = SSPI");
                //SqlConnection.Open();
            }
            return SqlConnection;
        }
    }
}