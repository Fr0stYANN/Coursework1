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
using System.Windows.Threading;
using WpfApp1.Content;
using WpfApp1.Views;

namespace WpfApp1.UserControls
{
    /// <summary>
    /// Interaction logic for QuestionsUC.xaml
    /// </summary>
    public partial class QuestionsUC : UserControl
    {
        public QuestionsUC()
        {
            InitializeComponent();
            //DispatcherTimer timer = new DispatcherTimer();
            //timer.Interval = TimeSpan.FromSeconds(1);
            //timer.Tick += timer_Tick;
            //timer.Start();
        }

        //void timer_Tick(object sender, EventArgs e)
        //{
        //    if (minutes >= TestIdContainer.TestMinutesLimit)
        //        StopTest();
        //    if (seconds >= 59)
        //    {
        //        seconds = 0;
        //        minutes++;
        //    }
        //    else
        //    {
        //        seconds++;
        //    }
        //    if (seconds < 10)
        //    {
        //        Lbl_Timer.Content = $"0{minutes}:0{seconds}";
        //    }
        //    else
        //    {
        //        Lbl_Timer.Content = $"0{minutes}:{seconds}";
        //    }
        //}

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window.Hide();
            CabinetWindow cabinetWindow = new CabinetWindow();
            cabinetWindow.Show();
        }
        private void StopTest()
        {
            MessageBox.Show("Час вичерпано", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
