using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.INPC;

namespace WpfApp1.Content
{
    public class BaseContent : OnPropertyChangedBaseImplementation
    {
        public RelayCommand JumpCommand { get; }
        public BaseContent(ExecuteHandler execute, CanExecuteHandler canExecute = null)
        {
            JumpCommand = new RelayCommand(execute, canExecute);
        }
    }
}
