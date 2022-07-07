using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace WpfApp1.INPC
{
    #region Делегати для команд
    public delegate void ExecuteHandler(object parameter);
    public delegate bool CanExecuteHandler(object parameter);
    #endregion
    public class RelayCommand : ICommand
    {
        private readonly CanExecuteHandler canExecute;
        private readonly ExecuteHandler onExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public RelayCommand(ExecuteHandler execute, CanExecuteHandler canExecute = null)
        {
            this.onExecute = execute;
            this.canExecute = canExecute;
        }
        public bool CanExecute(object parameter) => canExecute == null ? true : canExecute.Invoke(parameter);
        public void Execute(object parameter) => onExecute?.Invoke(parameter);
    }
}
