using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kwisspel.Controls
{
    class RelayCommand : ICommand
    {
        private Action<object> action;
        private Func<bool> canExecute;

        public RelayCommand(Action<object> action, Func<bool> canExecute)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute();
        }

        public void Execute(object parameter)
        {
            this.action(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
