using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerUI.Models
{
    public class ContractTypeDisplayModel : INotifyPropertyChanged
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string? Notes { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void CallPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
