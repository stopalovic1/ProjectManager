using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerUI.Models
{
    public class ContractDisplayModel
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBegining { get; set; }
        public DateTime DateOfEnding { get; set; }
        public string ContractNumber { get; set; }
        public string Investor { get; set; }
    }
}
