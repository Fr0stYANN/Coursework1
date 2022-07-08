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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace WpfApp1.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        UserRepository UserRepository = new UserRepository();
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            var login = loginTextBox.Text;
            var password = HashPassword.HashPasswordFunc(passwordTextBox.Password);
            var res = UserRepository.RegisterUser(password, login);
            if (res == 1)
            {
                MessageBox.Show("Ви успішно зареєструвались, натисніть кнопку увійти!", "Успішно!", MessageBoxButton.OK, MessageBoxImage.Information);
                var user = UserRepository.GetUser(login);
                DataBank.Login = login;
                DataBank.Password = password;
            }
            else
            {
                MessageBox.Show("Помилка реєстрації", "Помилка!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var login = loginTextBox.Text;
            var password = HashPassword.HashPasswordFunc(passwordTextBox.Password);
            var loginResult = UserRepository.CheckUserExists(password, login);
            XmlRepository xmlDataProvider = new XmlRepository();
            var test = xmlDataProvider.GetAllTests();
            if (loginResult == true)
            {
                this.Hide();
                MessageBox.Show("Ви успішно увійшли до особистого кабінету!!", "Вітаємо!",MessageBoxButton.OK,MessageBoxImage.Information);
                DataBank.Login = login;
                DataBank.Password = password;
                var user = UserRepository.GetUser(login);
                DataBank.IsTeacher = user.IsTeacher;
                DataBank.UserId = user.Id;
                DataBank.IsSuperAdmin = user.IsSuperAdmin;
                CabinetWindow window1 = new CabinetWindow();
                window1.Show();
            }
            else
            {
                MessageBox.Show("Не правильно введено логін або пароль!", "Помилка!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            DataBank.Login = login;
            DataBank.Password = password;
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
