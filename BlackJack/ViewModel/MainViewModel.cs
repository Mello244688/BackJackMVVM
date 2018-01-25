using GalaSoft.MvvmLight;
using System;

namespace BlackJack.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly static BlackJackViewModel blackJackViewModel = new BlackJackViewModel();
        private readonly static StartSceenViewModel startscreenViewModel = new StartSceenViewModel();

        private ViewModelBase currentView;
        public string Title { get; private set; }

        public ViewModelBase CurrentViewModel
        {
            get { return currentView; }
            private set
            {
                if (currentView == value)
                    return;
                currentView = value;
                RaisePropertyChanged(nameof(CurrentViewModel));
            }
        }

        public MainViewModel()
        {
            Title = "BlackJack Game";
            CurrentViewModel = startscreenViewModel;
            startscreenViewModel.ChangeView += StartscreenViewModel_ChangeView;
        }

        private void StartscreenViewModel_ChangeView(object sender, EventArgs e)
        {
            CurrentViewModel = blackJackViewModel;
        }
    }
}