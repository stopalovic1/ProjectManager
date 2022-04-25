using Caliburn.Micro;
using ProjectManager.Library.Internal.DataAccess;
using ProjectManagerUI.EventModels;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagerUI.ViewModels
{
    public class ContractorsViewModel : Screen
    {
        private readonly ISqlDataAccess _sql;
        private readonly IEventAggregator _eventAggregator;

        public ContractorsViewModel(ISqlDataAccess sql, IEventAggregator eventAggregator)
        {
            _sql = sql;
            _eventAggregator = eventAggregator;
        }



        public async Task AddContractorButton()
        {
            await _eventAggregator.PublishOnUIThreadAsync(new AddContractorEvent(), new CancellationToken());
        }

        public async Task BackToContractorsMenu()
        {
            await _eventAggregator.PublishOnUIThreadAsync(new MainMenuEvent(), new CancellationToken());
        }


    }
}
