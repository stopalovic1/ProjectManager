using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerUI.Models
{
    public class ContractDisplayModel : INotifyPropertyChanged
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

        public event PropertyChangedEventHandler? PropertyChanged;
        public void CallPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
