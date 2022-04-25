using Caliburn.Micro;
using ProjectManagerUI.ViewModels;
using ProjectManagerUI.EventModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagerUI.ViewModels
{
    public class ShellViewModel : Conductor<object>,
        IHandle<ProjectEvent>, IHandle<AddProjectEvent>, IHandle<AddContractEvent>,
        IHandle<ContractorEvent>, IHandle<AddContractorEvent>, IHandle<MainMenuEvent>
    {
        private readonly IEventAggregator _eventAggregator;
        private static string ParentScreenFromContractor = "";
        public ShellViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.SubscribeOnPublishedThread(this);
            ActivateItemAsync(IoC.Get<MainMenuViewModel>(), new CancellationToken());

        }

        public async Task HandleAsync(ProjectEvent message, CancellationToken cancellationToken)
        {
            await ActivateItemAsync(IoC.Get<ProjectsViewModel>(), cancellationToken);
        }

        public async Task HandleAsync(AddProjectEvent message, CancellationToken cancellationToken)
        {
            await ActivateItemAsync(IoC.Get<AddProjectViewModel>(), cancellationToken);
        }

        public async Task HandleAsync(AddContractEvent message, CancellationToken cancellationToken)
        {
            await ActivateItemAsync(IoC.Get<AddContractViewModel>(), cancellationToken);
        }

        public async Task HandleAsync(ContractorEvent message, CancellationToken cancellationToken)
        {
            ParentScreenFromContractor = message.ParentScreen;
            await ActivateItemAsync(IoC.Get<ContractorsViewModel>(), cancellationToken);
        }

        public async Task HandleAsync(AddContractorEvent message, CancellationToken cancellationToken)
        {
            await ActivateItemAsync(IoC.Get<AddContractorViewModel>(), cancellationToken);
        }

        public async Task HandleAsync(MainMenuEvent message, CancellationToken cancellationToken)
        {
            if (ParentScreenFromContractor == "MainMenuView")
            {
                await ActivateItemAsync(IoC.Get<MainMenuViewModel>(), cancellationToken);
            }
            else if (ParentScreenFromContractor == "ProjectsView")
            {
                await ActivateItemAsync(IoC.Get<ProjectsViewModel>(), cancellationToken);
            }
        }
    }
}
