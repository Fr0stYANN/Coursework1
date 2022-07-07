using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.INPC;
using WpfApp1.TestClasses;

namespace WpfApp1
{
    public class DataContainer : OnPropertyChangedBaseImplementation
    {
        private List<Test> tests;
        public List<Test> Tests { get => tests; set { tests = value; OnPropertyChanged(); } }
    }
}
