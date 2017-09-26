using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessor
{
    internal interface ILogDestination
    {
        void LogEntry(LogDTO logData);

        void SaveEntries();
    }
}
