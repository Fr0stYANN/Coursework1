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
using System.Data;
using System.Data.SqlClient;
namespace WpfApp1.Views
{
    /// <summary>
    /// Логика взаимодействия для MathWindow.xaml
    /// </summary>
    public partial class MathWindow : Window
    {
        public SqlDataAdapter adapter = new SqlDataAdapter();
        public DataTable dataTable = new DataTable();
        public MathWindow()
        {
            InitializeComponent();
            exitButton.Visibility = Visibility.Hidden;
        }
        RadioButton[] RadioButtons = new RadioButton[100];
        int Count = -1;
        int RadioCount = 0;
        List<string> Questions = new List<string>() { "2+2", "5+5", "6+6", "7+7", "8+8", "9+9", "10+10", "11+11", "12+12", "13+13" };
        List<string> Answers = new List<string>() { "1", "3", "4", "12", "15", "10", "12", "1", "12", "4", "16", "14", "18", "12", "16", "20", "4", "18", "15", "17", "20", "1", "3", "22", "10", "15", "24", "12", "11", "26" }; 
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            StartButton.Visibility = Visibility.Hidden;
            Count++;
            RadioCount += 3;
            LabelQuestionNum.Content = $"Номер питання: {Count + 1}";
            LabelQuestion.Content = Questions[Count];
            NextButton.Visibility = Visibility.Visible;
            for (int i = 0; i < RadioCount; i++)
            {
                RadioButton radioButton = new RadioButton();
                radioButton.Content = Answers[i];
                radioButton.IsChecked = false;
                RadioButtons[i] = radioButton;
                StackPanel.Children.Add(radioButton);
            }
        }
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            StackPanel.Children.Clear();
            RadioCount += 3;
            Count++;
            for (int i = RadioCount - 3; i < RadioCount; i++)
            {
                RadioButton radioButton = new RadioButton();
                radioButton.Content = Answers[i];
                radioButton.IsChecked = false;
                RadioButtons[i] = radioButton;
                StackPanel.Children.Add(radioButton);
            }
            LabelQuestionNum.Content = $"Номер питання: {Count + 1}";
            LabelQuestion.Content = Questions[Count];
            if(Count == 9)
            {
                exitButton.Visibility = Visibility.Visible;
            }
        }
        int points = 0;
        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            SetCorrect();
            LabelQuestion.Visibility = Visibility.Hidden;
            LabelQuestionNum.Visibility = Visibility.Hidden;
            NextButton.Visibility = Visibility.Hidden;
            exitButton.Visibility = Visibility.Hidden;
            SaveButton.Visibility = Visibility.Visible;
            StackPanel.Children.Clear();
            for(int i = 2; i < RadioCount; i++)
            {
                if (RadioButtons[i].GroupName == "Correct" && RadioButtons[i].IsChecked == true)
                {
                    points++;
                }
            }
            LabelResult.Content = $"Ваш результат = {points} балів";
            ResetButton.Visibility = Visibility.Visible;
            LabelResult.Visibility = Visibility.Visible;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //LabelQuestionNum.Visibility = Visibility.Hidden;
            //LabelQuestion.Visibility = Visibility.Hidden;
            //StackPanel.Children.Clear();
            //NextButton.Visibility = Visibility.Hidden;
            //int k = GetPoints();
            //LabelResult.Content = $"Ваш результат = {k} балів";
            //LabelResult.Visibility = Visibility.Visible;
            //ResetButton.Visibility = Visibility.Visible;
            //string queryString1 = $"UPDATE Users SET Points = {points} WHERE Login = '{DataBank.Login}' AND Password = '{DataBank.Password}'";
            //SqlCommand command = new SqlCommand(queryString1, dataBase.GetConnection());
            //dataBase.OpenConnection();
            //if (command.ExecuteNonQuery() == 1)
            //{
            //    MessageBox.Show("Ви успішно зберегли результат", "Успішно!", MessageBoxButton.OK, MessageBoxImage.Information);
            //}
            //dataBase.CloseConnection();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            points = 0;
            Count = -1;
            RadioCount = 0;
            LabelResult.Visibility = Visibility.Hidden;
            ResetButton.Visibility = Visibility.Hidden;
            LabelQuestionNum.Visibility = Visibility.Visible;
            LabelQuestion.Visibility = Visibility.Visible;
            Count++;
            RadioCount += 3;
            LabelQuestionNum.Content = $"Номер питання: {Count + 1}";
            LabelQuestion.Content = Questions[Count];
            NextButton.Visibility = Visibility.Visible;
            for (int i = 0; i < RadioCount; i++)
            {
                RadioButton radioButton = new RadioButton();
                radioButton.Content = Answers[i];
                radioButton.IsChecked = false;
                RadioButtons[i] = radioButton;
                StackPanel.Children.Add(radioButton);
            }
            NextButton.Visibility = Visibility.Visible;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CabinetWindow window1 = new CabinetWindow();
            window1.Show();
        }

        private void ExitButton_Click_1(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void SetCorrect()
        {
            RadioButtons[2].GroupName = "Correct";
            for(int i = 2; i < RadioCount; i+=3)
            {
                RadioButtons[i].GroupName = "Correct";
            }
        }
    }
}
