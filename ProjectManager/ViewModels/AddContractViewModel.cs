using Caliburn.Micro;
using ProjectManager.Library.Internal.DataAccess;
using ProjectManager.Library.Tables;
using ProjectManagerUI.EventModels;
using ProjectManagerUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;
using System.Dynamic;
using System.Windows;

namespace ProjectManagerUI.ViewModels
{
    public class AddContractViewModel : Screen
    {
        private readonly ISqlDataAccess _sql;
        private readonly IEventAggregator _eventAggregator;
        private readonly StatusInfoViewModel _status;
        private readonly IWindowManager _window;

        public AddContractViewModel(ISqlDataAccess sql, IEventAggregator eventAggregator, StatusInfoViewModel status, IWindowManager window)
        {
            _sql = sql;
            _eventAggregator = eventAggregator;
            _status = status;
            _window = window;
        }

        private BindingList<ProjectDisplayModel> _projectsComboBox;

        public BindingList<ProjectDisplayModel> ProjectsComboBox
        {
            get { return _projectsComboBox; }
            set
            {
                _projectsComboBox = value;
                NotifyOfPropertyChange(() => ProjectsComboBox);
            }
        }

        private ProjectDisplayModel _selectedProjectItem;

        public ProjectDisplayModel SelectedProjectItem
        {
            get { return _selectedProjectItem; }
            set
            {
                _selectedProjectItem = value;
                NotifyOfPropertyChange(() => SelectedProjectItem);
            }
        }


        private string _contractName;

        public string ContractName
        {
            get { return _contractName; }
            set
            {
                _contractName = value;
                NotifyOfPropertyChange(() => ContractName);
            }
        }

        private string _client;

        public string Client
        {
            get { return _client; }
            set
            {
                _client = value;
                NotifyOfPropertyChange(() => Client);
            }
        }


        private string _contractNumber;

        public string ContractNumber
        {
            get { return _contractNumber; }
            set
            {
                _contractNumber = value;
                NotifyOfPropertyChange(() => ContractName);
            }
        }

        private DateTime _dateOfBeginning;

        public DateTime DateOfBeginning
        {
            get { return _dateOfBeginning; }
            set
            {
                _dateOfBeginning = value;
                NotifyOfPropertyChange(() => DateOfBeginning);
            }
        }

        private string _financingMethod;

        public string FinancingMethod
        {
            get { return _financingMethod; }
            set
            {
                _financingMethod = value;
                NotifyOfPropertyChange(() => FinancingMethod);
            }
        }


        private DateTime _dateOfEnding;

        public DateTime DateOfEnding
        {
            get { return _dateOfEnding; }
            set
            {
                _dateOfEnding = value;
                NotifyOfPropertyChange(() => DateOfEnding);
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


        private string _investor;

        public string Investor
        {
            get { return _investor; }
            set
            {
                _investor = value;
                NotifyOfPropertyChange(() => Investor);
            }
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);

            var projects = await _sql.GetAllAsync<Project>();

            var productDisplayModel = new List<ProjectDisplayModel>();
            foreach (var project in projects)
            {
                var pdm = new ProjectDisplayModel
                {
                    Id = project.Id,
                    ContractedValue = project.ContractedValue,
                    Status = project.Status,
                    Contracts = new List<ContractDisplayModel>(),
                    FundSource = project.FundSource,
                    GrossValue = project.GrossValue,
                    Notes = project.Notes,
                    Owner = project.Owner,
                    ProjectName = project.ProjectName,
                    UserId = project.UserId
                };
                productDisplayModel.Add(pdm);
            }

            ProjectsComboBox = new BindingList<ProjectDisplayModel>(productDisplayModel);

        }


        public async Task SaveContract()
        {

            var contract = new Contract
            {
                ProjectId = SelectedProjectItem.Id,
                ContractName = ContractName,
                Client = Client,
                ContractNumber = ContractNumber,
                DateOfBeginning = DateOfBeginning,
                DateOfEnding = DateOfEnding,
                FinancingMethod = FinancingMethod,
                Investor = Investor,
                Notes = Notes,
                ContractTypeId = null
            };

            try
            {
                int id = await _sql.InsertAsync(contract);
                dynamic settings = new ExpandoObject();
                settings.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                settings.ResizeMode = ResizeMode.NoResize;
                settings.Title = "Ugovor dodan";
                _status.UpdateMessage("Uspjesno!", $"Ugovor {contract.ContractName} za projekat {SelectedProjectItem.ProjectName} uspjesno dodan!");
                await _window.ShowDialogAsync(_status, null, settings);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }
        public async Task BackToMenu()
        {
            await _eventAggregator.PublishOnUIThreadAsync(new ProjectEvent(), new CancellationToken());
        }


    }
}
