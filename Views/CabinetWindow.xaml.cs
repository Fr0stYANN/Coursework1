using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;
using System.Data;
using System.Windows.Threading;
using WpfApp1.Views;
using WpfApp1.TestClasses;

namespace WpfApp1.Views
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class CabinetWindow : Window
    {
        public List<Test> Tests { get; set; }
        public CabinetWindow()
        {
             InitializeComponent();
            XmlDataProvider xmlDataProvider = new XmlDataProvider();
            var tests = xmlDataProvider.GetAllTests();
            Tests = tests.Where(t => t.IsActive == true).ToList();
            availableTests.ItemsSource = Tests;
            if (DataBank.IsTeacher == true)
            {
                TeacherButton.Visibility = Visibility.Visible;
            }
            if(DataBank.IsSuperAdmin == true)
            {
                ManageUsers.Visibility = Visibility.Visible;
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
        private void StartTest(object sender, RoutedEventArgs e)
        {
            var testId = (availableTests.SelectedItem as Test).TestId;
            this.Hide();
            TestBeginningWindow testBeginningWindow = new TestBeginningWindow(testId);
            testBeginningWindow.Show();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Tests[0].IsActive == true)
            {
                this.Hide();
                TestBeginningWindow testBeginningWindow = new TestBeginningWindow(0);
                testBeginningWindow.Show();
            }
            else
            {
                MessageBox.Show("Даний тест не є активним!", "Помилка!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            if (Tests[1].IsActive == true)
            {
                this.Hide();
                TestBeginningWindow testBeginningWindow = new TestBeginningWindow(1);
                testBeginningWindow.Show();
            }
            else
            {
                MessageBox.Show("Даний тест не є активним!", "Помилка!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AuthWindow mainWindow = new AuthWindow();
            mainWindow.Show();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void a_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CreateTestWindow createTestWindow = new CreateTestWindow();
            createTestWindow.Show();
        }

        private void CheckResults_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            if (DataBank.IsTeacher)
            {
                CheckResultsWindow checkResultsWindow = new CheckResultsWindow();
                checkResultsWindow.Show();
            }
            else
            {
                UserCheksResultWindow userCheksResultWindow = new UserCheksResultWindow();
                userCheksResultWindow.Show();
            }
        }

        private void ManageUsers_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ManageUsersPage manageUsersPage = new ManageUsersPage();
            manageUsersPage.Show();
        }
    }
}
