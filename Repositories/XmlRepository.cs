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
    public class XmlRepository
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(DataContainer));
        string FileString = @"C:\Users\Phoenix\Desktop\Coursework-main\WpfApp1\Test.xml";
        public List<Test> GetAllTests()
        {
            DataContainer data = new DataContainer();
            using (FileStream fs = new FileStream(FileString, FileMode.OpenOrCreate))
            {
                data = (DataContainer)xmlSerializer.Deserialize(fs);
            }
            return data.Tests;
        }
        public List<Test> SetSomeChanges(List<Test> Tests)
        {
            DataContainer data = new DataContainer();
            data.Tests = Tests;
            using(FileStream fs = new FileStream(FileString, FileMode.Truncate))
            {
                xmlSerializer.Serialize(fs, data);
            }
            return data.Tests;
        }
    }
}
