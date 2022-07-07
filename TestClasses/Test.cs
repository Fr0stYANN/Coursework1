using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WpfApp1.INPC;

namespace WpfApp1.TestClasses
{
    [Serializable()]
    public partial class Test : OnPropertyChangedBaseImplementation
    {
        private string testName;
        private bool isActive; 
        public string TestName { get => testName; set { testName = value; OnPropertyChanged(); } }
        public bool IsActive { get => isActive; set { isActive = value; OnPropertyChanged(); }}
        public int TestId { get; set; }
        public int MinutesLimit { get; set; }
        [XmlArrayItem("Question", IsNullable = false)]
        public List<TestQuestion> Questions { get; set; }
    }
}
