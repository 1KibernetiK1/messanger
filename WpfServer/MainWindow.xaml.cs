using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

namespace WpfServer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Thread readThread; // нужно для обработки входящих сообщении
       
        public MainWindow()
        {
            InitializeComponent();
            
            readThread = new Thread(new ThreadStart(RunServer));
            readThread.Start();
        }


      

        // позволяет клиенту подключиться
        public void RunServer()
        {
            Socket _connection;
            TcpListener _listener;
            int counter = 1;  
                 
                IPAddress local = IPAddress.Parse("127.0.0.1");
                _listener = new TcpListener(IPAddress.Any, 8000);

                _listener.Start();
                DisplayMessage("Ожидайте подключения\r\n");

                while (true)
                {    
                    _connection = _listener.AcceptSocket();
                    DisplayMessage("Поключение " + counter + " Полученно.\r\n");
                    counter++;
                } 
           
        } 
          

        /// <summary>
        /// Для того чтобы показать имеется ли подключение или нет
        /// </summary>
        /// <param name="message"></param>
        private void DisplayMessage(string _message)
        {
            // если изменение отображаемого текстового поля не является безопасным
            if (!Display.Dispatcher.CheckAccess())
            {
                // используется унаследованный вызов метода для выполнения DisplayMessage
                // через делегата                                   
                Display.Dispatcher.Invoke(new Action(()
                                                 => Display.Text += _message));

            } 
          
        } 
         

    }
}
