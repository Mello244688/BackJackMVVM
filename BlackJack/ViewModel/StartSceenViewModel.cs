using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;

namespace BlackJack.ViewModel
{
    public class StartSceenViewModel : ViewModelBase
    {
        public ICommand StartGame { get; private set; }
        public ICommand QuitGame { get; private set; }

        public event EventHandler ChangeView;

        public StartSceenViewModel()
        {
            StartGame = new RelayCommand(ExecuteStartGame);
            QuitGame = new RelayCommand(ExecuteQuitGame);
        }

        private void ExecuteQuitGame()
        {
            System.Environment.Exit(0);
        }

        private void ExecuteStartGame()
        {
            OnChangeView(new EventArgs());
        }

        protected virtual void OnChangeView(EventArgs e)
        {
            EventHandler handler = ChangeView;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
