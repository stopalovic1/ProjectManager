using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ProjectManagerUI.EventModels;

namespace ProjectManagerUI.ViewModels
{
    public class MainMenuViewModel : Screen
    {
        private readonly IEventAggregator _eventAggregator;

        public MainMenuViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }
        
        public async Task ProjectButton()
        {
            await _eventAggregator.PublishOnUIThreadAsync(new ProjectEvent(), new CancellationToken());
        }

    }
}
