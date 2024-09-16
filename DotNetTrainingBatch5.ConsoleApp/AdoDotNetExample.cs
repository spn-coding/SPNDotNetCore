using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

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

            // foreach (DataRow dr in dt.Rows)
            // {
            //     Console.WriteLine(dr["BlogId"]);
            //     Console.WriteLine(dr["BlogTitle"]);
            //     Console.WriteLine(dr["BlogAuthor"]);
            //     Console.WriteLine(dr["BlogContent"]);
            //     Console.WriteLine(dr["DeleteFlag"]);
            // }

            Console.WriteLine("Connection closing...");
            connection.Close();
            Console.WriteLine("Connection closing...");


            // DataSet
            // DataTable
            // DataRow
            // DataColumn

            // foreach (DataRow dr in dt.Rows)
            // {
            //     Console.WriteLine(dr["BlogId"]);
            //     Console.WriteLine(dr["BlogTitle"]);
            //     Console.WriteLine(dr["BlogAuthor"]);
            //     Console.WriteLine(dr["BlogContent"]);
            //     Console.WriteLine(dr["DeleteFlag"]);
            // }

        }

        public void Create()
        {
            Console.WriteLine("Blog Title: ");
            var title = Console.ReadLine();

            Console.WriteLine("Blog Author: ");
            var author = Console.ReadLine();

            Console.WriteLine("Blog Content: ");
            var content = Console.ReadLine();

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            // string queryInsert = $@"INSERT INTO DotNetTrainingBatch5.dbo.Tbl_Blog
            //                         (BlogTitle, 
            //                         BlogAuthor, 
            //                         BlogContent, 
            //                         DeleteFlag)
            //                     VALUES(
            //                         '{title}', 
            //                         '{author}', 
            //                         '{content}', 
            //                         0)";


            string queryInsert = $@"INSERT INTO DotNetTrainingBatch5.dbo.Tbl_Blog
                                    (BlogTitle, 
                                    BlogAuthor, 
                                    BlogContent, 
                                    DeleteFlag)
                                VALUES(
                                    @BlogTitle,
                                    @BlogAuthor,
                                    @BlogContent,
                                    0)";

            SqlCommand cmd = new SqlCommand(queryInsert, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);

            // SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            // DataTable dt = new DataTable();
            // adapter.Fill(dt);

            int result = cmd.ExecuteNonQuery();

            connection.Close();


            // if (result == 1)
            // {
            //     Console.WriteLine("Saving Successful.");
            // }
            // else
            // {
            //     Console.WriteLine("Saving Failed.");
            // }

            Console.WriteLine(result == 1 ? "Saving Successful." : "Saving Failed.");

        }

        public void Edit()
        {
            Console.Write("Blog Id: ");
            var id = Console.ReadLine();

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = $@"SELECT BlogId, BlogTitle, BlogAuthor, BlogContent, DeleteFlag
                            FROM DotNetTrainingBatch5.dbo.Tbl_Blog WHERE BlogId = @id";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No Data Found!");
                return;
            }

            DataRow dr = dt.Rows[0];
            Console.WriteLine(dr["BlogId"]);
            Console.WriteLine(dr["BlogTitle"]);
            Console.WriteLine(dr["BlogAuthor"]);
            Console.WriteLine(dr["BlogContent"]);
        }



    }
}