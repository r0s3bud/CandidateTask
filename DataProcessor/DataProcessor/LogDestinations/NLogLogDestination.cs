using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessor
{
    public class NLogLogDestination : ILogDestination
    {
        private Logger logger;

        public NLogLogDestination()
        {
            logger = LogManager.GetLogger("UserDataLogger");
        }

        public void LogEntry(LogDTO logData)
        {
            logger.Log(LogLevel.Info, $"{logData.FirstName},{logData.LastName}");
        }

        public void SaveEntries()
        {          
        }
    }
}
