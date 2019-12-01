using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterForm
{
    public class Database
    {
        private  string connectionString { get; set; }

        public Database(string database)
        {
            connectionString = ConfigurationManager.ConnectionStrings[database].ConnectionString;
        }
        public  void SendQuery(string query,Action<SqlCommand> proccess)
        {
            using (SqlConnection connection= new SqlConnection(connectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    proccess(command);
                }
            }

        }

        public void CanfigurateSQLDataReader(SqlCommand command,Action<SqlDataReader> process)
        {
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                process(reader);
            }
        }
    }
}
