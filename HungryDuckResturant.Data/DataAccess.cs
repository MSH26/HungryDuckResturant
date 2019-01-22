using System;
using System.Data.SqlClient;

using HungryDuckResturant.Entity;

namespace HungryDuckResturant.Data
{
    public class DataAccess
    {
        static SqlConnection conn;

        static SqlConnection Connection
        {
            get
            {
                conn = new SqlConnection(HungryDuckResturant.Data.Properties.Settings.Default.HungryDuckResturantDB);
                conn.Open();
                return conn;
            }
        }

        public static int ExecuteQuery(string query)
        {
            SqlCommand cmd = new SqlCommand(query, Connection);
            return cmd.ExecuteNonQuery();
        }

        public static SqlDataReader GetData(string query)
        {
            SqlCommand cmd = new SqlCommand(query, Connection);
            return cmd.ExecuteReader();
        }
    }
}
