using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Library.Tables
{
    [Table("Project")]
    public class Project
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Owner { get; set; }
        public string ProjectName { get; set; }
        public double ContractedValue { get; set; }
        public double GrossValue { get; set; }
        public string Status { get; set; }
        public string FundSource { get; set; }
        public string Notes { get; set; }

    }
}
