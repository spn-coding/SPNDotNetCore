using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DotNetTrainingBatch5.ConsoleApp.Models;

namespace DotNetTrainingBatch5.ConsoleApp
{
    public class DapperExample
    {
        private readonly string _connectionString = "Data Source=.;Initial Catalog=DotNetTrainingBatch5;User ID=sa;Password=sasa@123";
        public void Read()
        {
            // using (IDbConnection db = new SqlConnection(_connectionString))
            // {
            //     string query = "SELECT * FROM tbl_blog WHERE DeleteFlag = 0";
            //     var lst = db.Query(query).ToList();
            //     foreach (var item in lst)
            //     {
            //         Console.WriteLine(item.BlogId);
            //         Console.WriteLine(item.BlogTitle);
            //         Console.WriteLine(item.BlogAuthor);
            //         Console.WriteLine(item.BlogContent);
            //     }
            // }


            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM tbl_blog WHERE DeleteFlag = 0";
                var lst = db.Query<BlogDataModel>(query).ToList();
                foreach (var item in lst)
                {
                    Console.WriteLine(item.BlogId);
                    Console.WriteLine(item.BlogTitle);
                    Console.WriteLine(item.BlogAuthor);
                    Console.WriteLine(item.BlogContent);
                }
            }

            // DTO = Data Transfer Object
        }

        public void Create(string title, string author, string content)
        {
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

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                int result = db.Execute(queryInsert, new BlogDataModel
                {
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content
                });
                Console.WriteLine(result == 1 ? "Save Successful" : "Save Failed");
            }
        }

        public void Edit(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM tbl_blog WHERE BlogId = @BlogId";

                var item = db.Query<BlogDataModel>(query, new BlogDataModel
                {
                    BlogId = id
                }).FirstOrDefault();

                if (item is null)
                {
                    Console.WriteLine("No Data Found!");
                    return;
                }

                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
        }

        public void Update(int id, string title, string author, string content)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM tbl_blog WHERE BlogId = @BlogId";
                string insertQuery = @"UPDATE DotNetTrainingBatch5.dbo.Tbl_Blog SET 
                                        BlogTitle = @BlogTitle, 
                                        BlogAuthor = @BlogAuthor, 
                                        BlogContent = @BlogContent, 
                                        DeleteFlag = 0
                                        WHERE BlogId = @BlogId";

                var lst = db.Query<BlogDataModel>(query, new BlogDataModel
                {
                    BlogId = id
                }).FirstOrDefault();

                if (lst is null)
                {
                    Console.WriteLine("No Data Found!");
                    return;
                }

                var result = db.Execute(insertQuery, new BlogDataModel
                {
                    BlogId = id,
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content
                });

                Console.WriteLine(result == 0 ? "Update Failed" : "Update Successful!");
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                // logical delete
                string query = "UPDATE DotNetTrainingBatch5.dbo.Tbl_Blog SET DeleteFlag = 1 WHERE BlogId = @BlogId";
                var result = db.Execute(query, new BlogDataModel
                {
                    BlogId = id
                });

                Console.WriteLine(result == 0 ? "Delete Failed!" : "Delete Successful!");
            }
        }
    }
}