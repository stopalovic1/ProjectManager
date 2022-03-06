using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ProjectManagerUI.EventModels;
using ProjectManager.Library.Internal.DataAccess;
using ProjectManager.Library.Tables;

namespace ProjectManagerUI.ViewModels
{
    public class MainMenuViewModel : Screen
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly ISqlDataAccess _sql;

        public MainMenuViewModel(IEventAggregator eventAggregator, ISqlDataAccess sql)
        {
            _eventAggregator = eventAggregator;
            _sql = sql;
        }

        public async Task ProjectButton()
        {
            await _eventAggregator.PublishOnUIThreadAsync(new ProjectEvent(), new CancellationToken());
        }

    }
}
