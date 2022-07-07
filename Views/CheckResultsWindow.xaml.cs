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

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for CheckResultsWindow.xaml
    /// </summary>
    public partial class CheckResultsWindow : Window
    {
        public ObservableCollection<TestAttempt> Attempts { get; set; }
        public CheckResultsWindow()
        {
            InitializeComponent();
            UserRepository userRepository = new UserRepository();
            var attempts =  userRepository.GetAllResults();
            ObservableCollection<TestAttempt> attemptsObservable = new ObservableCollection<TestAttempt>(attempts);
            Attempts = attemptsObservable;
            dgResults.ItemsSource = Attempts;
        }

        private void delete_Record_Click(object sender, RoutedEventArgs e)
        {
            var attempt = (TestAttempt)dgResults.SelectedItem;
            UserRepository userRepository = new UserRepository();
            userRepository.DeleteAttempt(attempt.AttemptId);
            Attempts.Remove(attempt);
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
