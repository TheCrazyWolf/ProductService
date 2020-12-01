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
        private DB.ProductServiceEntities ef = new DB.ProductServiceEntities();
        public AddOrChanger()
        {
            InitializeComponent();
            stack.DataContext = ef.Products.ToList();
        }
    }
}
