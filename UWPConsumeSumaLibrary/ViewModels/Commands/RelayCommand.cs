using System;
using System.Windows.Input;

namespace UWPConsumeSumaLibrary.ViewModels.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Action actionAExecuter;

        public RelayCommand(Action action)
        {
            actionAExecuter = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            actionAExecuter();
        }
    }
}