using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;

namespace XamarinEFCoreSample.Models
{
    public class TodoDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        private string _databaseName = "Todo.db";

        private string _databasePath
        {
            get
            {
                try
                {
                    return $"{FileSystem.AppDataDirectory}{Path.DirectorySeparatorChar}{_databaseName}";
                }
                catch
                {
                    return _databaseName;
                }
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={_databasePath}");
        }
    }
}
