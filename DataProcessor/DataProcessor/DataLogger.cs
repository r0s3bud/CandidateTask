using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace DataProcessor
{
    public class DataLogger         
    {
        private List<ILogDestination> logDestinationsCollection = new List<ILogDestination>();

        public DataLogger()
        {
            logDestinationsCollection.Add(new NLogLogDestination());
            logDestinationsCollection.Add(new XmlFileLogDestination());
            logDestinationsCollection.Add(new DatabaseLogDestination());
        }

        public void Log(IEnumerable<UserDataModel> userData)
        {           
            var mapper = AutoMapperBootstrapper.GetMapper();
            IEnumerable<LogDTO> logData = mapper.Map<IEnumerable<LogDTO>>(userData);
            foreach (LogDTO entry in logData)
            {
                foreach (ILogDestination logDest in logDestinationsCollection)
                {
                        logDest.LogEntry(entry);                                        
                }
            }

            foreach (ILogDestination logDest in logDestinationsCollection)
            {
                try
                {
                    logDest.SaveEntries();
                }   
                catch (Exception ex)
                {                   
                }
            }            
        }
    }
}
