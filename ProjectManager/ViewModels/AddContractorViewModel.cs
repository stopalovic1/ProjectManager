using Caliburn.Micro;
using ProjectManager.Library.Internal.DataAccess;
using ProjectManager.Library.Tables;
using ProjectManagerUI.EventModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectManagerUI.ViewModels
{
    public class AddContractorViewModel : Screen
    {


        private readonly ISqlDataAccess _sql;
        private readonly StatusInfoViewModel _status;
        private readonly IWindowManager _window;
        private readonly IEventAggregator _eventAggregator;

        public AddContractorViewModel(ISqlDataAccess sql, StatusInfoViewModel status, IWindowManager window, IEventAggregator eventAggregator)
        {
            _sql = sql;
            _status = status;
            _window = window;
            _eventAggregator = eventAggregator;
        }

        private string _firmName;
        public string FirmName
        {
            get { return _firmName; }
            set
            {
                _firmName = value;
                NotifyOfPropertyChange(() => FirmName);
            }
        }

        private string _ownerLastName;
        public string OwnerLastName
        {
            get { return _ownerLastName; }
            set
            {
                _ownerLastName = value;
                NotifyOfPropertyChange(() => OwnerLastName);
            }
        }

        private string _ownerFirstName;
        public string OwnerFirstName
        {
            get { return _ownerFirstName; }
            set
            {
                _ownerFirstName = value;
                NotifyOfPropertyChange(() => OwnerFirstName);
            }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyOfPropertyChange(() => Title);
            }
        }

        private string _jmbg;
        public string JMBG
        {
            get { return _jmbg; }
            set
            {
                _jmbg = value;
                NotifyOfPropertyChange(() => JMBG);
            }
        }

        private string _oib;
        public string OIB
        {
            get { return _oib; }
            set
            {
                _oib = value;
                NotifyOfPropertyChange(() => OIB);
            }
        }

        private string _businessPhone;
        public string BusinessPhone
        {
            get { return _businessPhone; }
            set
            {
                _businessPhone = value;
                NotifyOfPropertyChange(() => BusinessPhone);
            }
        }

        private string _personalPhone;
        public string PersonalPhone
        {
            get { return _personalPhone; }
            set
            {
                _personalPhone = value;
                NotifyOfPropertyChange(() => PersonalPhone);
            }
        }

        private string _fax;
        public string Fax
        {
            get { return _fax; }
            set
            {
                _fax = value;
                NotifyOfPropertyChange(() => Fax);
            }
        }

        private string _Address;
        public string Address
        {
            get { return _Address; }
            set
            {
                _Address = value;
                NotifyOfPropertyChange(() => Address);
            }
        }

        private string _city;
        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                NotifyOfPropertyChange(() => City);
            }
        }

        private string _postalCode;
        public string PostalCode
        {
            get { return _postalCode; }
            set
            {
                _postalCode = value;
                NotifyOfPropertyChange(() => PostalCode);
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                NotifyOfPropertyChange(() => Email);
            }
        }

        private string _webSite;


        public string WebSite
        {
            get { return _webSite; }
            set
            {
                _webSite = value;
                NotifyOfPropertyChange(() => WebSite);
            }
        }

        private string _notes;

        public string Notes
        {
            get { return _notes; }
            set
            {
                _notes = value;
                NotifyOfPropertyChange(() => Notes);
            }
        }



        public async Task SaveContractor()
        {
            var contractor = new Contractor
            {
                Address = _Address,
                BusinessPhone = BusinessPhone,
                City = City,
                Email = Email,
                Fax = Fax,
                FirmName = FirmName,
                JMBG = JMBG,
                Notes = Notes,
                OIB = OIB,
                OwnerLastName = OwnerLastName,
                OwnerName = OwnerFirstName,
                PersonalPhone = PersonalPhone,
                PostalCode = PostalCode,
                WebSite = WebSite
            };

            try
            {
                int id = await _sql.InsertAsync(contractor);
                dynamic settings = new ExpandoObject();
                settings.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                settings.ResizeMode = ResizeMode.NoResize;
                settings.Title = "Ugovor dodan";
                _status.UpdateMessage("Uspjesno!", $"Izvodjac radova: {contractor.FirmName} uspjesno dodan!");
                await _window.ShowDialogAsync(_status, null, settings);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public async Task BackToMenu()
        {
            await _eventAggregator.PublishOnUIThreadAsync(new ContractorEvent(), new CancellationToken());
        }
    }
}
