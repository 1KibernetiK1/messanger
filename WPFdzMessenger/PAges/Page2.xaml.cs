using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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

namespace WPFdzMessenger.PAges
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        private NetworkStream output; // Для приема данных       
        private Thread readThread; // Нужно для включения клиента

        public Page2()
        {
            InitializeComponent();

            readThread = new Thread(new ThreadStart(RunClient));
            readThread.Start();
        }

        private void Input_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Return && Input.IsEnabled == true)
            {
                TxtDisplay.Text += "\r\nСергеев Павел: " + Input.Text;
                Input.Clear();
            }

        }

        public void RunClient()
        {
            TcpClient client = null;

            // Отправка данных на сервер

            MessageBox.Show("Успешное подключение");
            client = new TcpClient();
            client.Connect("localhost", 8000);
            output = client.GetStream();
        }
    }
}
