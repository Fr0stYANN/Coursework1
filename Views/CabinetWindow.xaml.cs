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

namespace WpfApp1.Views
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class CabinetWindow : Window
    {
        //DataBase dataBase = new DataBase();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable dataTable = new DataTable();
        public CabinetWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //dataGrid.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //this.Hide();
            //MathWindow mathWindow = new MathWindow();
            //mathWindow.Show();

            this.Hide();
            TestBeginningWindow testBeginningWindow = new TestBeginningWindow();
            testBeginningWindow.Show();
            //string point;
            //var login = DataBank.Login;
            //var password = DataBank.Password;
            //string queryString = $"select Points from Users where Login = '{login}' and Password = '{password}'";
            //SqlCommand sqlCommand = new SqlCommand(queryString, dataBase.GetConnection());
            //adapter.SelectCommand = sqlCommand;
            //adapter.Fill(dataTable);
            //dataGrid.ItemsSource = dataTable.DefaultView;
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
    }
}
