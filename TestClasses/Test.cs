using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WpfApp1.TestClasses
{
    [Serializable()]
    public partial class Test
    {
        public string TestName { get; set; }
        [XmlArrayItem("Question", IsNullable = false)]
        public List<TestQuestion> Questions { get; set; }
    }
}
