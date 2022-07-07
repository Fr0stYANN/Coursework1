using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfApp1.UserData;

namespace WpfApp1.Views
{
    /// <summary>
    /// Логика взаимодействия для ManageUsersPage.xaml
    /// </summary>
    public partial class ManageUsersPage : Window
    {
        public ObservableCollection<User> Users { get; set; }
        AttemptRepository attemptRepository = new AttemptRepository();
        UserRepository userRepository = new UserRepository();
        public ManageUsersPage()
        {
            InitializeComponent();
            var users = userRepository.GetAllUsers();
            Users = new ObservableCollection<User>(users);
            dgUsers.ItemsSource = Users;
        }

        private void deleteUser_Click(object sender, RoutedEventArgs e)
        {
            var user = (User)dgUsers.SelectedItem;
            userRepository.DeleteUser(user.Id);
            Users.Remove(user);
        }

        private void makeIsTeacher_Click(object sender, RoutedEventArgs e)
        {
            var user = (User)dgUsers.SelectedItem;
            attemptRepository.MakeUserTeacher(user.Id);
            var index = Users.IndexOf(Users.Where(userr => userr.Id == user.Id).FirstOrDefault());
            Users[index].IsTeacher = true;
        }

        private void makeIsSuperAdmin_Click(object sender, RoutedEventArgs e)
        {
            var user = (User)dgUsers.SelectedItem;
            attemptRepository.MakeUserSuperAdmin(user.Id);
            var index = Users.IndexOf(Users.Where(userr => userr.Id == user.Id).FirstOrDefault());
            Users[index].IsSuperAdmin = true;
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ManageUsersPage manageUsersPage = new ManageUsersPage();
            manageUsersPage.Show();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CabinetWindow cabinetWindow = new CabinetWindow();
            cabinetWindow.Show();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
