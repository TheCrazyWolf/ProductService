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

namespace ProductService.Forms
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
            if (App.TypeUser == "admin")
            {
                btn_users.Visibility = Visibility.Visible;
                Title = "Режим администратора";
                tb_welcome.Text = "Режим администратора";
            }
            
        }

        private void btn_products_Click(object sender, RoutedEventArgs e)
        {
            Forms.CatalogProducts catalog = new CatalogProducts();
            catalog.Show();
            Close();
        }
    }

    
}

