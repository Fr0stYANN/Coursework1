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
            var users = userRepository.GetAllUsers().Where(user => user.Id != DataBank.UserId);
            Users = new ObservableCollection<User>(users);
            dgUsers.ItemsSource = Users;
            textBox1.Text = "Введіть логін користувача";
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
            attemptRepository.MakeUserTeacher(user.Id, user.IsTeacher);
            var index = Users.IndexOf(Users.Where(userr => userr.Id == user.Id).FirstOrDefault());
            Users[index].IsTeacher = !Users[index].IsTeacher;
            var newUsers = Users;
            dgUsers.Items.Refresh();
        }

        private void makeIsSuperAdmin_Click(object sender, RoutedEventArgs e)
        {
            var user = (User)dgUsers.SelectedItem;
            attemptRepository.MakeUserSuperAdmin(user.Id, user.IsSuperAdmin);
            var index = Users.IndexOf(Users.Where(userr => userr.Id == user.Id).FirstOrDefault());
            Users[index].IsSuperAdmin = !Users[index].IsSuperAdmin;
            var newUsers = Users;
            dgUsers.Items.Refresh();
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
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox1.Text != "Введіть логін користувача")
            {
                var filtered = Users.Where(user => user.Login.Contains(textBox1.Text.ToString())).ToList();
                dgUsers.ItemsSource = filtered;
            }
        }
        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text)) textBox1.Text = "Введіть логін користувача";
        }
        private void textBox1_MouseEnter_1(object sender, MouseEventArgs e)
        {
            textBox1.Text = String.Empty;
        }
    }
}
