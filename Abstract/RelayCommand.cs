using System;
using System.Windows.Input;

namespace Tournaments.WPF.Abstract
{
    public class RelayCommand : ICommand
    {
        private Action Command;
        public RelayCommand(Action action)
        {
            Command = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Command();
        }
    }
}
