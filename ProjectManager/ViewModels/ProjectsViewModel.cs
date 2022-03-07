using Caliburn.Micro;
using ProjectManagerUI.Models;
using System.ComponentModel;
using System.Windows.Controls;
using System.Collections.Generic;
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

        public ContractDisplayModel SelectedContractItem
        {
            get { return _selectedContractItem; }
            set
            {
                _selectedContractItem = value;
                NotifyOfPropertyChange(() => SelectedContractItem);
            }
        }



        public ProjectsViewModel()
        {
            Projects = new BindingList<ProjectDisplayModel>
            {
                new ProjectDisplayModel { Id=1,Name ="Senad",LastName="Topalovic",
                    Contracts = new List<ContractDisplayModel>
                    {
                        new ContractDisplayModel{ Id=1,ProjectId=1,Name="Ugovor1",Investor="Senad" },
                        new ContractDisplayModel{ Id=2,ProjectId=1,Name="Ugovor2",Investor="Senad" },
                        new ContractDisplayModel{ Id=3,ProjectId=1,Name="Ugovor3",Investor="Senad" },
                        new ContractDisplayModel{ Id=3,ProjectId=1,Name="Ugovor3",Investor="Senad" },
                        new ContractDisplayModel{ Id=3,ProjectId=1,Name="Ugovor3",Investor="Senad" },
                        new ContractDisplayModel{ Id=3,ProjectId=1,Name="Ugovor3",Investor="Senad" }
                    }
                },
                new ProjectDisplayModel { Id=2,Name ="Emil",LastName ="Topalovic",
                    Contracts=new List<ContractDisplayModel>
                    {
                        new ContractDisplayModel{ Id=1,ProjectId=2,Name="Ugovor1",Investor="Emil"},
                        new ContractDisplayModel{ Id=2,ProjectId=2,Name="Ugovor2",Investor="Emil"},
                        new ContractDisplayModel{ Id=3,ProjectId=2,Name="Ugovor3",Investor="Emil"}
                    }
                },
                new ProjectDisplayModel { Id=3,Name ="Semir",LastName="Suljevic",
                    Contracts= new List<ContractDisplayModel>
                    {
                        new ContractDisplayModel{ Id=1,ProjectId=3,Name="Ugovor1",Investor="Semir"},
                        new ContractDisplayModel{ Id=2,ProjectId=3,Name="Ugovor2",Investor="Semir"},
                        new ContractDisplayModel{ Id=3,ProjectId=3,Name="Ugovor3",Investor="Semir"}
                    }
                }
            };

        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            SelectedProjectItem = Projects[0];
        }




    }
}
