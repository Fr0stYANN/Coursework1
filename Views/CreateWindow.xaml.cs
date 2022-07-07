using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Linq;
using System.Xml.Serialization;
using WpfApp1.TestClasses;

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for CreateWindow.xaml
    /// </summary>
    public partial class CreateWindow : Window
    {
        public CreateWindow()
        {
            InitializeComponent();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    fullStackPanel.Children.Clear();
        //    int amount = int.Parse(txtQuestionsCount.Text);
        //    Label[] labels = new Label[amount];
        //    for(int i = 0; i < amount; i++)
        //    {
        //        Label label = new Label();
        //        label.Content = $"{i}";
        //        labels[i] = label;
        //        fullStackPanel.Children.Add(labels[i]);
        //    }
        //}

        private void UploadContent_Click(object sender, RoutedEventArgs e)
        {
         
        }
    }
}
