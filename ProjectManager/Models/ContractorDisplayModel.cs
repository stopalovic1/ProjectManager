using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerUI.Models
{
    public class ContractorDisplayModel : INotifyPropertyChanged
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
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string WebSite { get; set; }
        public string Notes { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void CallPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
