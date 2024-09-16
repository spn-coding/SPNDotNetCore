using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetTrainingBatch5.ConsoleApp
{
    public class AdoDotNetExample
    {
        private readonly string _connectionString = "Data Source=.;Initial Catalog=DotNetTrainingBatch5;User ID=sa;Password=sasa@123";

        public void Read()
        {
            Console.WriteLine("Connection string: " + _connectionString);
            SqlConnection connection = new SqlConnection(_connectionString);

            Console.WriteLine("Connection opening...");
            connection.Open();
            Console.WriteLine("Connection opened.");

            string query = @"SELECT BlogId, BlogTitle, BlogAuthor, BlogContent, DeleteFlag
                            FROM DotNetTrainingBatch5.dbo.Tbl_Blog WHERE DeleteFlag = 0";

            SqlCommand cmd = new SqlCommand(query, connection);
            // SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            // DataTable dt = new DataTable();
            // adapter.Fill(dt);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader["BlogId"]);
                Console.WriteLine(reader["BlogTitle"]);
                Console.WriteLine(reader["BlogAuthor"]);
                Console.WriteLine(reader["BlogContent"]);
            }

            Console.WriteLine("Connection closing...");
            connection.Close();
            Console.WriteLine("Connection closing...");
        }
    }
}