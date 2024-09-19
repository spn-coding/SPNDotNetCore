using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetTrainingBatch5.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetTrainingBatch5.ConsoleApp
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = "Data Source=.;Initial Catalog=DotNetTrainingBatch5;User ID=sa;Password=sasa@123;TrustServerCertificate=True;";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        public DbSet<BlogEfCoreDataModel> Blogs { get; set; }
    }
}