using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WpfApp1.TestClasses
{
    [Serializable()]
    public partial class TestQuestion 
    {
        public string QuestionText { get; set; }
        [XmlArrayItem("Answer", IsNullable = false)]
        public List<TestAnswer> Answers { get; set; }
    }
}
