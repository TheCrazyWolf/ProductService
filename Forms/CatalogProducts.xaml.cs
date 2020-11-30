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

namespace ProductService.Forms
{
    /// <summary>
    /// Логика взаимодействия для CatalogProducts.xaml
    /// </summary>
    public partial class CatalogProducts : Window
    {
        public CatalogProducts()
        {
            InitializeComponent();
            try
            {
                Controllers.Controller controller = new Controllers.Controller();
                lb_products.ItemsSource = controller.Viewers;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
