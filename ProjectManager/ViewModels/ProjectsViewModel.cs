using Caliburn.Micro;
using ProjectManagerUI.Models;
using System.ComponentModel;
using System.Windows.Controls;

namespace ProjectManagerUI.ViewModels
{
    public class ProjectsViewModel : Screen, INotifyPropertyChanged
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


        public void SelectionChanged(object e, SelectionChangedEventArgs args)
        {

        }

        public ProjectsViewModel()
        {
            Projects = new BindingList<ProjectDisplayModel>
            {
                new ProjectDisplayModel { Id=1,Name ="Senad",LastName="Topalovic" },
                new ProjectDisplayModel { Id=2,Name ="Semir",LastName ="Suljevic"},
                new ProjectDisplayModel { Id=3,Name ="Amar",LastName="Fejzic" }
            };

        }




    }
}
