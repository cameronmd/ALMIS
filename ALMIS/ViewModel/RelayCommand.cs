using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ALMIS.ViewModel
{
    public class RelayCommand : ICommand
    {
        // Fields
        private readonly Action<object> _executionAction;
        private readonly Predicate<object> _canExecuteAction;

        // Constructors
        public RelayCommand(Action<object> executionAction)
        {
            _executionAction = executionAction;
            _canExecuteAction = null;
        }

        public RelayCommand(Action<object> executionAction, Predicate<object> canExecuteAction)
        {
            _executionAction = executionAction;
            _canExecuteAction = canExecuteAction;
        }

        // Events 
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value;  }
            remove { CommandManager.RequerySuggested -= value; }
        }

        // Methods 
        public bool CanExecute(object? parameter)
        {
            return _canExecuteAction == null ? true : _canExecuteAction(parameter);
        }

        public void Execute(object? parameter)
        {
            _executionAction(parameter);
        }
    }
}
