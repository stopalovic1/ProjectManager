using Caliburn.Micro;
using ProjectManager.Library.Internal.DataAccess;
using ProjectManager.Library.Tables;
using ProjectManagerUI.EventModels;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagerUI.ViewModels
{
    public class AddProjectViewModel : Screen
    {




        public AddProjectViewModel(ISqlDataAccess sql, IEventAggregator aggregator)
        {
            _sql = sql;
            _aggregator = aggregator;
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

        public string Notes
        {
            get { return _notes; }
            set
            {
                _notes = value;
                NotifyOfPropertyChange(() => Notes);
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
            project.FundSource = "Bice dodano kasnije";
            project.Status = "Bice dodano kasnije";

            try
            {
                await _sql.InsertAsync(project);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }
        public async Task BackToMenu()
        {
            await _aggregator.PublishOnUIThreadAsync(new ProjectEvent(), new CancellationToken());
        }

    }
}
