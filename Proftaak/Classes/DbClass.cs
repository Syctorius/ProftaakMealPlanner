using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak.Classes
{
    class DbClass
    {
        

        private string connectionString = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
        public SqlConnection connection { get; set; }



        public DbClass()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public SqlDataReader ReadSQL(string queryString)
        {
            SqlCommand command =
                new SqlCommand(queryString, connection);

            SqlDataReader reader = command.ExecuteReader();

            // Call Read before accessing data.
            return reader;
        }
    }
}
