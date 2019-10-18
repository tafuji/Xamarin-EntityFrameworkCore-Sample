using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging.Debug;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;

namespace XamarinEFCoreSample.Models
{
    public class TodoDbContext : DbContext
    {
        public static readonly LoggerFactory loggerFactory = 
            new LoggerFactory(new[]
            { 
                new DebugLoggerProvider((_, __) => _== DbLoggerCategory.Database.Command.Name && __ == LogLevel.Information)
            });

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
            optionsBuilder
                .UseLoggerFactory(loggerFactory)
                .EnableSensitiveDataLogging()
                .UseSqlite($"Data Source={_databasePath}");
        }
    }
}
