using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessor
{
    [Serializable]
    public class UserDataModel
    {                
        public UserDataModel()
        {
        }

        public enum Gender
        {
            male,
            female
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public Gender UserGender { get; set; }

        public ushort Age { get; set; }
    }
}
