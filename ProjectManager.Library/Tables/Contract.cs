using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Library.Tables
{
    [Table("Contract")]
    public class Contract
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int? ContractTypeId { get; set; }
        public string ContractName { get; set; }
        public string Client { get; set; }
        public DateTime DateOfBeginning { get; set; }
        public DateTime DateOfEnding { get; set; }
        public string ContractNumber { get; set; }
        public string FinancingMethod { get; set; }
        public string Investor { get; set; }

        public string Notes { get; set; }
    }
}
