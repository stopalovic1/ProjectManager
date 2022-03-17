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
    public class ShellViewModel : Conductor<object>, IHandle<ProjectEvent>, IHandle<AddProjectEvent>, IHandle<AddContractEvent>, IHandle<ContractorEvent>, IHandle<AddContractorEvent>
    {
        private readonly IEventAggregator _eventAggregator;

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
            await ActivateItemAsync(IoC.Get<ContractorsViewModel>(), cancellationToken);
        }

        public async Task HandleAsync(AddContractorEvent message, CancellationToken cancellationToken)
        {
            await ActivateItemAsync(IoC.Get<AddContractorViewModel>(), cancellationToken);
        }
    }
}
