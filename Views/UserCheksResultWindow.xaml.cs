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
    /// Interaction logic for UserCheksResultWindow.xaml
    /// </summary>
    public partial class UserCheksResultWindow : Window
    {
        public ObservableCollection<TestAttempt> Attempts { get; set; }
        AttemptRepository attemptRepository = new AttemptRepository();
        public UserCheksResultWindow()
        {
            InitializeComponent();
            var attempts = attemptRepository.GetAllResults().Where(User => DataBank.Login == User.UserLogin).ToList();
            ObservableCollection<TestAttempt> attemptsObservable = new ObservableCollection<TestAttempt>(attempts);
            Attempts = attemptsObservable;
            dgResults.ItemsSource = Attempts;
            textBox1.Text = "Введіть дисципліну";
        }

        private void delete_Record_Click(object sender, RoutedEventArgs e)
        {
            var attempt = (TestAttempt)dgResults.SelectedItem;
            attemptRepository.DeleteAttempt(attempt.AttemptId);
            Attempts.Remove(attempt);
            dgResults.Items.Refresh();
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
            if (textBox1.Text != "Введіть дисципліну")
            {
                var filtered = Attempts.Where(attempt => attempt.TestName.Contains(textBox1.Text.ToString())).ToList();
                dgResults.ItemsSource = filtered;
            }
        }

        private void textBox1_MouseEnter(object sender, MouseEventArgs e)
        {
            textBox1.Text = String.Empty;
        }

        private void textBox1_MouseLeave(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text)) textBox1.Text = "Введіть дисципліну";
        }
    }
}
