using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WpfApp1.TestClasses;

namespace WpfApp1.Models
{
    public class TestModel
    {
        public Test Test { get; set; }
        public string TestFileName { get; set; }
        public TestModel(string testFileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(DataContainer));
            DataContainer data;
            //using (FileStream fs = new FileStream(@"C:\Users\Phoenix\Desktop\Visual Studio Projects\WpfLearningApp\WpfLearningApp\Tests.xml", FileMode.Truncate))
            //{
            //    xmlSerializer.Serialize(fs, data);
            //}
            using (FileStream fs = new FileStream(@"C:\Users\Phoenix\Desktop\Coursework-main\WpfApp1\Test.xml", FileMode.OpenOrCreate))
            {
                data = (DataContainer)xmlSerializer.Deserialize(fs);
            }
            Test = data.Tests[0];
        }
        public TestModel() : this(@"C:\Users\Phoenix\Desktop\Coursework-main\WpfApp1\Test.xml") { }
    }
}
