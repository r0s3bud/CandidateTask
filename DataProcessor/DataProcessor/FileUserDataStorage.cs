using AutoMapper;
using NLog;
using NLog.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessor
{
    public class FileUserDataStorage : IUserStorage
    {        
        private Logger logger = LogManager.GetLogger("userDataSavingLogger");

        private string filePath;

        public FileUserDataStorage() : this(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
        {
        }

        public FileUserDataStorage(string newFilePath)
        {
            filePath = newFilePath;
        }

        public void Save(UserDataModel userData)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<UserDataModel, LogDTO>());                        
            using (StreamWriter outputFile = new StreamWriter(filePath + @"\UserData.txt", true))
            {
                outputFile.WriteLine(userData.FirstName + " "
                    + userData.LastName + " "
                    + userData.Address + " " +
                    userData.UserGender + " " +
                    userData.Age);
            }

            var userDataLog = Mapper.Map<UserDataModel, LogDTO>(userData);
            logger.Log(LogLevel.Info, $"User has saved user data : {userDataLog.FirstName},{userDataLog.LastName}");
        }
    }
}
