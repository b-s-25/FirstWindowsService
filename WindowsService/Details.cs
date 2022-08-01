using LINQtoCSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService
{
    [Serializable]
   public  class Details
    {
        [CsvColumn(Name = "employeID", FieldIndex = 1)]
        public string EmployeId { get; set; }
        [CsvColumn(Name = "displayName", FieldIndex = 2)]
        public string DisplayName { get; set; }
        [CsvColumn(Name = "giveName", FieldIndex = 3)]
        public string GiveName { get; set; }
        [CsvColumn(Name = "sn", FieldIndex = 4)]
        public string SN { get; set; }
        [CsvColumn(Name = "department", FieldIndex = 5)]
        public string Department { get; set; }
        [CsvColumn(Name = "mail", FieldIndex = 6)]
        public string Email { get; set; }
        [CsvColumn(Name = "title", FieldIndex = 7)]
        public string Title { get; set; }
        [CsvColumn(Name = "manager", FieldIndex = 8)]
        public string Manager { get; set; }

    }
}
