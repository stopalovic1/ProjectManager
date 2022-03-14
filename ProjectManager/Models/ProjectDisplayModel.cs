using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerUI.Models
{
    public class ProjectDisplayModel : INotifyPropertyChanged
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
        public List<ContractDisplayModel> Contracts { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;
        public void CallPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
