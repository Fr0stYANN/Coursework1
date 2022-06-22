using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace WpfApp1.INPC
{
    #region Делегаты для методов WPF команд
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
        /// <returns>True - если выполнение команды разрешено</returns>
        public bool CanExecute(object parameter) => canExecute == null ? true : canExecute.Invoke(parameter);

        /// <summary>Вызов выполняющего метода команды</summary>
        /// <param name="parameter">Параметр команды</param>
        public void Execute(object parameter) => onExecute?.Invoke(parameter);
    }
}
