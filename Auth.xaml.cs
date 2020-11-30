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
using System.Net.NetworkInformation;
using System.Threading;

namespace ProductService
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public Auth()
        {
            InitializeComponent();
            
            Thread thread = new Thread(new ThreadStart(VerifyConnect)); //запуск метода в отдельном потоке
            thread.Start();
        }

        /// <summary>
        /// Проверка подключение из локальной сети и настройка Entities
        /// </summary>
        public void VerifyConnect()
        {
            Dispatcher.Invoke(() => lb_status.Text = "Ожидание ответа от 192.168.10.160");
            Ping png = new Ping();
            PingReply pingReply = png.Send("192.168.10.160");
            if (pingReply.Status == IPStatus.Success)
            {
                App.TypeConnect = "local";
                Dispatcher.Invoke(() => lb_status.Foreground = Brushes.DarkGreen);
                Dispatcher.Invoke(() => lb_status.Text = "Используется локальное подключение");
                Dispatcher.Invoke(() => btn_enter.IsEnabled = true);
                Dispatcher.Invoke(() => lb_status.ToolTip = "Для соединение с базой данных будет использован следующий IP - 192.168.10.160");
            }
            else
            {

                Dispatcher.Invoke(() => lb_status.Text = "Ожидание ответа от 85.236.170.148");
                PingReply pingReply1 = png.Send("85.236.170.148");
                if (pingReply1.Status == IPStatus.Success)
                {
                    App.TypeConnect = "global";
                    Dispatcher.Invoke(() => lb_status.Foreground = Brushes.DarkGreen);
                    Dispatcher.Invoke(() => lb_status.Text = "Используется внешнее подключение");
                    Dispatcher.Invoke(() => btn_enter.IsEnabled = true);
                    Dispatcher.Invoke(() => lb_status.ToolTip = "Для соединение с базой данных будет использован следующий IP - 85.236.170.148");

                }
                else
                {
                    Dispatcher.Invoke(() => lb_status.Foreground = Brushes.Red);
                    Dispatcher.Invoke(() => lb_status.Text = "Нет доступных подключений. Следующая попытка через 3 секунды");
                    Dispatcher.Invoke(() => btn_enter.IsEnabled = false);
                    Dispatcher.Invoke(() => lb_status.ToolTip = "Не смогли обнаружить возможность подключение к базе данных. Возможно нет интернета?");
                    Thread.Sleep(3000);
                    Dispatcher.Invoke(() => lb_status.Foreground = Brushes.Black);
                    VerifyConnect();

                }
            }
        }

        private void rb_local_Click(object sender, RoutedEventArgs e)
        {
            App.TypeConnect = "local";
            lb_status.Text = "Задано подключение вручную: 192.168.10.160";
            btn_enter.IsEnabled = true;
        }

        private void rb_global_Click(object sender, RoutedEventArgs e)
        {
            App.TypeConnect = "global";
            lb_status.Text = "Задано подключение вручную: 85.236.170.148";
            btn_enter.IsEnabled = true;
        }

        private void lb_status_MouseUp(object sender, MouseButtonEventArgs e)
        {
            rb_global.Visibility = Visibility.Visible; rb_local.Visibility = Visibility.Visible;
        }

        private void btn_enter_Click(object sender, RoutedEventArgs e)
        {
            DB.ProductServiceEntities ef = new DB.ProductServiceEntities();

            var user = ef.users.Where(x => x.login == tb_login.Text && x.password == tb_password.Password).SingleOrDefault();
            if (user != null)
            {
                if (tb_login.Text == "admin")
                {
                    App.TypeUser = "admin";
                }
                Forms.Menu menu = new Forms.Menu();
                menu.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Неверный логин-пароль. Проверьте правильность введеных вами данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                tb_login.Text = ""; tb_password.Password = "";
            }
        }

        private void btn_forgot_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    
}

