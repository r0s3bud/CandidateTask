using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Reflection;

namespace DataProcessor
{
    public class XmlFileLogDestination : ILogDestination
    {
        private readonly string filePath;

        private List<LogDTO> entries;       

        public XmlFileLogDestination() : this(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/xmlLog.xml")
        {
        }

        public XmlFileLogDestination(string path)
        {
            entries = new List<LogDTO>();
            filePath = path;
        }

        public void LogEntry(LogDTO logData)
        {
            entries.Add(logData);
        }

        public void SaveEntries()
        {
            XDocument doc;
            try
            {
                doc = XDocument.Load(filePath);
            }
            catch (FileNotFoundException)
            {
                doc = new XDocument(new XElement("Users"));
            }

            AddToXmlFile(doc);
        }

        #region HelperMethods
        private void AddToXmlFile(XDocument doc)
        {
            var rootElement = doc.Element("Users");
            foreach (LogDTO entry in entries)
            {
                XElement logEntryElement = new XElement("UserDataLog", new XElement("UserInfo", $"{entry.FirstName},{entry.LastName}"), new XElement("TimeOfEntry", DateTime.Now.ToString()));
                rootElement.Add(logEntryElement);
            }
            
            doc.Save(filePath);
        }
        #endregion
    }
}
