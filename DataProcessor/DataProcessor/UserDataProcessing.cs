using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessor
{
    public static class UserDataProcessing
    {
        public static void SaveToFile(UserDataModel userData)
        {
            string myDocsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile = new StreamWriter(myDocsPath + @"\UserData.txt"))
            {
                outputFile.WriteLine(userData.FirstName);
                outputFile.WriteLine(userData.LastName);
                outputFile.WriteLine(userData.Address);
                outputFile.WriteLine(userData.UserGender);
                outputFile.WriteLine(userData.Age);
            }                
        }
    }
}
