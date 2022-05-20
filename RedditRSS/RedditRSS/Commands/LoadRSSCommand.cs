using System;
using System.Windows.Input;

namespace RedditRSS.Commands
{
    public class LoadRSSCommand : ICommand
    {

        private readonly Action<string> _execute;
        public event EventHandler? CanExecuteChanged;

        public LoadRSSCommand(Action<string> execute)
        {
            _execute = execute;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is not null)
            {
                _execute((string)parameter);
            }
        }
    }
}
