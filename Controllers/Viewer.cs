using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductService.DB;

namespace ProductService.Controllers
{

    /// <summary>
    /// Помогите мне, у меня демонстрационный экзамен скоро :С
    /// </summary>
    public class Viewer
    {

        /// Поля из БДшки
        public int IdProduct { get; set; }
        public string IdManufacter { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Price { get; set; }
        public string MainFilePath { get; set; }

        /// <summary>
        /// Конструктор вьевера
        /// </summary>
        /// <param name="products"></param>
        public Viewer(DB.Products products)
        {
            Title = GetTitle(products); ;
            Status = GetStatus(products);
            Price = GetPrice(products);
            MainFilePath = GetMainFilePath(products);
            IdProduct = products.IdProduct;
        }

        private string GetMainFilePath(Products products)
        {
            return products.MainFilePath;
        }

        private string GetPrice(Products products)
        {
            return Convert.ToString(products.Price /80) + "$";
        }

        private string GetStatus(Products products)
        {
            return products.Status;
        }

        private string GetTitle(Products products)
        {
            return products.Title;
        }
    }
}
