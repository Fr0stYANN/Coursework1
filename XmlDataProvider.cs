using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WpfApp1.TestClasses;

namespace WpfApp1
{
    public class XmlDataProvider
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(DataContainer));
        public List<Test> GetAllTests()
        {
            DataContainer data = new DataContainer();
            using (FileStream fs = new FileStream(@"C:\Users\Phoenix\Desktop\Coursework-main\WpfApp1\Test.xml", FileMode.OpenOrCreate))
            {
                data = (DataContainer)xmlSerializer.Deserialize(fs);
            }
            return data.Tests;
        }
    }
}
