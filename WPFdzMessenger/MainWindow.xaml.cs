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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFdzMessenger
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Button btn = (Button)sender;
            string tag = btn.Tag.ToString();
            string pageName = $"Page{tag}.xaml";

            var uri = new Uri("Pages/" + pageName, UriKind.Relative);
            mainFrame.Navigate(uri);
        }

        private void Click_Exit(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

      
    }
}
