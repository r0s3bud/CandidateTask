using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProcessor;
using System.ComponentModel.DataAnnotations;
using DataProcessor.DatabaseConnector;
using System.Data.SQLite;

namespace DataProcessor.DatabaseConnector
{
    public class DatabaseContext : DbContext
    {        
        public DatabaseContext() : base("UserDataLogs")
        {            
        }

        public DbSet<LogEntryEntity> Entries { get; set; }
    }
}
