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

        protected Controllers.Viewer viewer;
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

        private void Btn_edit_Click(object sender, RoutedEventArgs e)
        {

            var tp = e.OriginalSource as Button;

            
            var bt = e.OriginalSource as Button;

            var product = bt.DataContext as Controllers.Viewer;

            MessageBox.Show(e.OriginalSource.ToString());

            Forms.AddOrChanger addOrChanger = new AddOrChanger(product);

            if (addOrChanger.ShowDialog() == true)
            {
                Controllers.Controller controller = new Controllers.Controller();
                lb_products.ItemsSource = controller.Viewers;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {


               
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
