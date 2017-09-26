using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessor.DatabaseConnector
{
    [Table("UserLogs")]
    public class LogEntryEntity
    {
        public LogEntryEntity()
        {
            Date = DateTime.Now;
        }

        [Key]
        public int ID { get; set; }

        [Column("FirstName", TypeName = "varchar")]
        public string FirstName { get; set; }

        [Column("LastName", TypeName = "varchar")]
        public string LastName { get; set; }

        [Column("Date", TypeName = "datetime")]
        public DateTime? Date { get; private set; }
    }
}