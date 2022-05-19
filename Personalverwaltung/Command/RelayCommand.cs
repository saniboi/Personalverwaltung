using System;
using System.Windows.Input;

namespace Personalverwaltung.Command
{
    internal class RelayCommand : ICommand
    {
        private readonly Action<object> executeHandler;
        private readonly Predicate<object> canExecuteHandler;
        public RelayCommand(Action<object> execute) : this(execute, null){}

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            executeHandler = execute ?? throw new ArgumentNullException($"Execute kann nicht null sein.");
            canExecuteHandler = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            return canExecuteHandler == null || canExecuteHandler(parameter);
        }

        public void Execute(object parameter)
        {
            executeHandler(parameter);
        }

    }
}
