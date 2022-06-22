using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.INPC;
namespace WpfApp1.Content
{
    public class TitleContent : BaseContent
    {
        private string testName;

        public string TestName { get => testName; set { testName = value; OnPropertyChanged(); } }
        public TitleContent(ExecuteHandler execute, CanExecuteHandler canExecute = null) : base(execute, canExecute)
        {

        }
        
    }
}
