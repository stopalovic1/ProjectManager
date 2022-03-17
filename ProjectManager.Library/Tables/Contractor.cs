using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Library.Tables
{
    [Table("Contractor")]
    public class Contractor
    {
        public int Id { get; set; }
        public string FirmName { get; set; }
        public string OwnerName { get; set; }
        public string OwnerLastName { get; set; }
        public string JMBG { get; set; }
        public string OIB { get; set; }
        public string Email { get; set; }
        public string PersonalPhone { get; set; }
        public string BusinessPhone { get; set; }
        public string Fax { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string WebSite { get; set; }
        public string Notes { get; set; }

    }
}
