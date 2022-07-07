using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;
using WpfApp1.TestClasses;

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for CreateTestWindow.xaml
    /// </summary>
    public partial class CreateTestWindow : Window
    {
        public ObservableCollection<Test> Tests { get; set; }
        public CreateTestWindow()
        {
            InitializeComponent();
            XmlDataProvider xmlDataProvider = new XmlDataProvider();
            List<Test> NeededTestsFromXml = new List<Test>(xmlDataProvider.GetAllTests());
            Tests = new ObservableCollection<Test>(NeededTestsFromXml);
            testss.ItemsSource = Tests;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (testss.SelectedItem as Test).IsActive = !(testss.SelectedItem as Test).IsActive;
            XmlDataProvider xmlDataProvider = new XmlDataProvider();
            List<Test> tests = new List<Test>(Tests);
            xmlDataProvider.SetSomeChanges(tests);
            //submit_button.Visibility = Visibility.Hidden;
            //string Number = QuestionsCount.Text.ToString();
            //int NumberInt = int.Parse(Number);
            //string TestNamed = TestName.ToString();
            //MainStackPanel.Children.Clear();
            //for (int i = 0; i < NumberInt; i++)
            //{
            //    Label labelInput = new Label();
            //    labelInput.Content = $"Question {i + 1}";
            //    labelInput.Name = $"label{i + 1}";
            //    MainStackPanel.Children.Add(labelInput);
            //    TextBox textBox = new TextBox();
            //    textBox.Name = $"textBox{i + 1}";
            //    MainStackPanel.Children.Add(textBox);
            //    Thickness thickness = textBox.Margin;
            //    //textBox.Margin = new Thickness(60, 10, 10, 10);
            //    //textBox.SetValue(Grid.RowProperty, 1);
            //}
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CabinetWindow cabinetWindow = new CabinetWindow();
            cabinetWindow.Show();
        }

        private void UploadContent_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new OpenFileDialog();
            XmlDataProvider xmlDataProvider = new XmlDataProvider();
            DataContainer dataContainer = new DataContainer();
            bool? response = openFileDialog.ShowDialog();
            if (response == true)
            {
                string filepath = openFileDialog.FileName;
                Test test = new Test();
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Test));
                using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate))
                {
                    test = (Test)xmlSerializer.Deserialize(fs);
                }
                if(test != null)
                {
                    dataContainer.Tests = xmlDataProvider.GetAllTests();
                    dataContainer.Tests.Add(test);
                    Tests.Add(test);
                    xmlDataProvider.SetSomeChanges(dataContainer.Tests);
                }
            }
        }

        private void DeleteTest_Click(object sender, RoutedEventArgs e)
        {
            Tests.Remove(testss.SelectedItem as Test);
            XmlDataProvider xmlDataProvider = new XmlDataProvider();
            DataContainer dataContainer = new DataContainer();
            List<Test> tests = new List<Test>(Tests);
            dataContainer.Tests = tests;
            xmlDataProvider.SetSomeChanges(dataContainer.Tests);
        }

        private void Reload_Page_Click(object sender, RoutedEventArgs e)
        {
            CreateTestWindow createTestWindow = new CreateTestWindow();
            createTestWindow.Show();
            this.Hide();
        }
    }
}
