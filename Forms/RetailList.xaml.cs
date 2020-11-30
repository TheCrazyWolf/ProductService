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
    /// Логика взаимодействия для RetailList.xaml
    /// </summary>
    public partial class RetailList : Window
    {
        public RetailList()
        {
            InitializeComponent();
            DB.ProductServiceEntities ef = new DB.ProductServiceEntities();
            datagrid.ItemsSource = ef.Manufacters.ToList();
        }

       
    }
}
