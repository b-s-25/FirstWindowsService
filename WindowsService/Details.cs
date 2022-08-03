using CsvHelper.Configuration.Attributes;

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
        [Name("employeID")]
        public string EmployeId { get; set; }
        [Name("displayName")]
        public string DisplayName { get; set; }
        [Name("giveName")]
        public string GiveName { get; set; }
        [Name("sn")]
        public string SN { get; set; }
        [Name("department")]
        public string Department { get; set; }
        [Name("mail")]
        public string Email { get; set; }
        [Name("title")]
        public string Title { get; set; }
        [Name("manager")]
        public string Manager { get; set; }

    }
}
