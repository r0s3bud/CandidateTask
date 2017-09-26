using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProcessor.DatabaseConnector;

namespace DataProcessor
{
    public class DatabaseLogDestination : ILogDestination
    {
        private DatabaseContext dbContext = new DatabaseContext();

        public void LogEntry(LogDTO logData)
        {            
            dbContext.Entries.Add(AutoMapperBootstrapper.GetMapper().Map<LogEntryEntity>(logData));
        }

        public void SaveEntries()
        {
            dbContext.SaveChanges();
        }
    }
}
