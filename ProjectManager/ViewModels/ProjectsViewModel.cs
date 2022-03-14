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
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Configuration;

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

            var conn = ConfigurationManager.ConnectionStrings["ProjectManagerDB"].ConnectionString;

            using (IDbConnection connection = new SqlConnection(conn))
            {

                string sql = @"select * from dbo.Project p left join dbo.Contract c on p.Id=c.ProjectId;";
                var dic = new Dictionary<int, ProjectDisplayModel>();
                var projects = (await connection.QueryAsync<ProjectDisplayModel, ContractDisplayModel, ProjectDisplayModel>(sql, (project, contract) =>
                {
                    ProjectDisplayModel model;
                    if (!dic.TryGetValue(project.Id, out model))
                    {
                        model = project;
                        model.Contracts = new List<ContractDisplayModel>();
                        dic.Add(model.Id, model);
                    }
                    if (contract != null)
                        model.Contracts.Add(contract);

                    return model;
                })).Distinct().ToList();

                Projects = new BindingList<ProjectDisplayModel>(projects);
                if (Projects.Count != 0)
                {
                    SelectedProjectItem = Projects[0];
                }
            }
        }
        public async Task AddProjectButton()
        {
            await _eventAggregator.PublishOnUIThreadAsync(new AddProjectEvent(), new CancellationToken());
        }

        public async Task AddContractButton()
        {
            await _eventAggregator.PublishOnUIThreadAsync(new AddContractEvent(), new CancellationToken());
        }


    }
}
