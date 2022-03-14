using Caliburn.Micro;
using ProjectManager.Library.Internal.DataAccess;
using ProjectManager.Library.Tables;
using ProjectManagerUI.EventModels;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Dynamic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectManagerUI.ViewModels
{
    public class AddProjectViewModel : Screen
    {

        public AddProjectViewModel(ISqlDataAccess sql, IEventAggregator aggregator, IWindowManager window, StatusInfoViewModel status)
        {
            _sql = sql;
            _aggregator = aggregator;
            _window = window;
            _status = status;
        }
        private string _projectName;
        public string ProjectName
        {
            get { return _projectName; }
            set
            {
                _projectName = value;
                NotifyOfPropertyChange(() => ProjectName);
            }
        }

        private double _contractedValue;

        public double ContractedValue
        {
            get { return _contractedValue; }
            set
            {
                _contractedValue = value;
                NotifyOfPropertyChange(() => ContractedValue);
            }
        }

        private double _grossValue;

        public double GrossValue
        {
            get { return _grossValue; }
            set
            {
                _grossValue = value;
                NotifyOfPropertyChange(() => GrossValue);
            }
        }


        private string _owner;

        public string Owner
        {
            get { return _owner; }
            set
            {
                _owner = value;
                NotifyOfPropertyChange(() => Owner);
            }
        }

        private string _notes;
        private readonly ISqlDataAccess _sql;
        private readonly IEventAggregator _aggregator;
        private readonly IWindowManager _window;
        private readonly StatusInfoViewModel _status;

        public string Notes
        {
            get { return _notes; }
            set
            {
                _notes = value;
                NotifyOfPropertyChange(() => Notes);
            }
        }


        private string _fundSourceItem;

        public string FundSourceItem
        {
            get { return _fundSourceItem; }
            set
            {
                _fundSourceItem = value;
                NotifyOfPropertyChange(() => FundSourceItem);
            }
        }


        public async Task SaveProject()
        {
            var project = new Project();
            project.GrossValue = GrossValue;
            project.Owner = Owner;
            project.UserId = 1;
            project.ProjectName = ProjectName;
            project.ContractedValue = ContractedValue;
            project.Notes = Notes;
            project.FundSource = FundSourceItem;
            project.Status = StatusItem;

            try
            {
                int id = await _sql.InsertAsync(project);
                dynamic settings = new ExpandoObject();
                settings.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                settings.ResizeMode = ResizeMode.NoResize;
                settings.Title = "Projekt dodan";
                _status.UpdateMessage($"Projekat {project.ProjectName} uspjesno dodan!", "");
                await _window.ShowDialogAsync(_status, null, settings);
                ResetViewModel();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }
        private BindingList<string> _fundSourceComboBox;

        public BindingList<string> FundSourceComboBox
        {
            get { return _fundSourceComboBox; }
            set
            {
                _fundSourceComboBox = value;
                NotifyOfPropertyChange(() => FundSourceComboBox);
            }
        }


        private BindingList<string> _statusComboBox;

        public BindingList<string> StatusComboBox
        {
            get { return _statusComboBox; }
            set
            {
                _statusComboBox = value;
                NotifyOfPropertyChange(() => StatusComboBox);
            }
        }



        private string _statusItem;

        public string StatusItem
        {
            get { return _statusItem; }
            set { _statusItem = value; }
        }



        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            FundSourceComboBox = new BindingList<string>
            {
                "Investicije - HV",
                "Investicije - Opcine",
                "Interni radovi",
                "Kooperatnski radovi"
            };

            StatusComboBox = new BindingList<string>
            {
                "Nije zapoceto",
                "U obradi",
                "Odgodeno",
                "Ceka na nekog drugog",
                "Dovrseno"
            };
            StatusItem = StatusComboBox[0];

        }


        private void ResetViewModel()
        {
            ProjectName = string.Empty;
            Owner = string.Empty;
            GrossValue = 0;
            ContractedValue = 0;
            Notes = string.Empty;
            StatusItem = StatusComboBox[0];
            FundSourceItem = FundSourceComboBox[0];
        }



        public async Task BackToMenu()
        {
            await _aggregator.PublishOnUIThreadAsync(new ProjectEvent(), new CancellationToken());
        }





    }
}
