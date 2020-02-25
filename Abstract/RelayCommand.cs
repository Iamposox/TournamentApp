using System;
using System.Diagnostics;
using System.Windows;
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

    //Second Replay Command Supporting Generic Parameters
    public class RelayCommand<T> : ICommand
    {
        readonly Action<T> _execute = null;
        readonly Predicate<T> _canExecute = null;
        public RelayCommand(Action<T> execute) : this(execute, null)
        {

        }
        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }
        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute((T)parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }
    }
}
