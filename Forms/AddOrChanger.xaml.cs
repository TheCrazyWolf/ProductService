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
    /// Логика взаимодействия для AddOrChanger.xaml
    /// </summary>
    public partial class AddOrChanger : Window
    {
        private DB.Products products = new DB.Products();



        public AddOrChanger()
        {
            InitializeComponent();
            stack.DataContext = products;

            cb_box.ItemsSource = new DB.ProductServiceEntities().Manufacters.ToList();
            cb_retail.ItemsSource = new string[] { "активен", "неактивен" };
        }

        public AddOrChanger(Controllers.Viewer viewer)
        {
            InitializeComponent();
            cb_box.ItemsSource = new DB.ProductServiceEntities().Manufacters.ToList();
            cb_retail.ItemsSource = new string[] { "активен", "неактивен" };
            Controllers.Controller controller = new Controllers.Controller(viewer);
            stack.DataContext = controller.Product;



            cb_retail.SelectedItem = (cb_retail.ItemsSource as string[]).Single(x => x == controller.Product.Status);

            cb_box.SelectedItem = (cb_box.ItemsSource as List<DB.Manufacters>).Single(x => x.IdManufacter == controller.Product.IdManufacter);


          
        }
        
    }
}
