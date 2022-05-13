using System;
using System.Windows.Input;

namespace RedditRSS.Commands
{
    public class LoadRSSCommand : ICommand
    {

        private readonly Action<string> _execute;
        private readonly Func<string, bool> _canExecute;
        public event EventHandler? CanExecuteChanged;

        public LoadRSSCommand(Action<string> execute, Func<string, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute(parameter as string);
        }

        public void Execute(object? parameter)
        {
            _execute(parameter as string);
        }
    }
}
