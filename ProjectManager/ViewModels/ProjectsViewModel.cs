using Caliburn.Micro;
using ProjectManagerUI.Models;
using System.ComponentModel;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using ProjectManagerUI.EventModels;
using ProjectManager.Library.Internal.DataAccess;
using ProjectManager.Library.Tables;

namespace ProjectManagerUI.ViewModels
{
    public class ProjectsViewModel : Screen
    {

        private BindingList<ProjectDisplayModel> _projects;

        public BindingList<ProjectDisplayModel> Projects
        {
            get { return _projects; }
            set
            {
                _projects = value;
                NotifyOfPropertyChange(() => Projects);
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
                NotifyOfPropertyChange(() => OwnerTextBox);
            }
        }

        private string _ownerTextBox = "aaaaa";

        public string OwnerTextBox
        {
            get
            {
                return _ownerTextBox;
            }
            set
            {
                _ownerTextBox = value;
                NotifyOfPropertyChange(() => OwnerTextBox);
            }
        }


        private BindingList<ContractDisplayModel> _contracts;

        public BindingList<ContractDisplayModel> Contracts
        {
            get { return _contracts; }
            set
            {
                _contracts = value;
                NotifyOfPropertyChange(() => Contracts);
            }
        }



        private ContractDisplayModel _selectedContractItem;
        private readonly IEventAggregator _eventAggregator;
        private readonly ISqlDataAccess _sql;

        public ContractDisplayModel SelectedContractItem
        {
            get { return _selectedContractItem; }
            set
            {
                _selectedContractItem = value;
                NotifyOfPropertyChange(() => SelectedContractItem);
            }
        }



        public ProjectsViewModel(IEventAggregator eventAggregator, ISqlDataAccess sql)
        {
            _eventAggregator = eventAggregator;
            _sql = sql;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);

            var products = await _sql.GetAllAsync<Project>();
            var productDisplayModel = new List<ProjectDisplayModel>();
            foreach (var product in products)
            {
                var pdm = new ProjectDisplayModel
                {
                    Id = product.Id,
                    ContractedValue = product.ContractedValue,
                    Status = product.Status,
                    Contracts = new List<ContractDisplayModel>(),
                    FundSource = product.FundSource,
                    GrossValue = product.GrossValue,
                    Notes = product.Notes,
                    Owner = product.Owner,
                    ProjectName = product.ProjectName,
                    UserId = product.UserId
                };
                productDisplayModel.Add(pdm);
            }

            Projects = new BindingList<ProjectDisplayModel>(productDisplayModel);
            if (Projects.Count != 0)
            {
                SelectedProjectItem = Projects[0];
            }
        }
        public async Task AddProjectButton()
        {
            await _eventAggregator.PublishOnUIThreadAsync(new AddProjectEvent(), new CancellationToken());
        }


    }
}
