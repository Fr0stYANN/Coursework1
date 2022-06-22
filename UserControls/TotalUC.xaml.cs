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
using WpfApp1.Views;

namespace WpfApp1.UserControls
{
    /// <summary>
    /// Interaction logic for TotalUC.xaml
    /// </summary>
    public partial class TotalUC : UserControl
    {
        public TotalUC()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserRepository userRepository = new UserRepository();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            CabinetWindow cabinetWindow = new CabinetWindow();
            cabinetWindow.Show();
        }
    }
}
