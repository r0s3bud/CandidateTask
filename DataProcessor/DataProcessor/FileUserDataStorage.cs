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
        private string filePath;

        public FileUserDataStorage()
        {
            filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        public FileUserDataStorage(string newFilePath)
        {
            filePath = newFilePath;
        }

        public void Save(UserDataModel userData)
        {            
            using (StreamWriter outputFile = new StreamWriter(filePath + @"\UserData.txt", true))
            {
                outputFile.WriteLine(userData.FirstName + " "
                    + userData.LastName + " "
                    + userData.Address + " " +
                    userData.UserGender + " " +
                    userData.Age);
            }
        }
    }
}
