using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WpfApp1.TestClasses
{
    [Serializable()]
    public partial class TestAnswer
    {
        [XmlAttribute()]
        public bool IsRight { get; set; }
        /// <summary>Текст ответа</summary>
        [XmlText()]
        public string AnswerText { get; set; }
    }
}
