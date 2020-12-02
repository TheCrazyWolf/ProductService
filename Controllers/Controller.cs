using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Controllers
{
    /// Помогите мне, у меня демонстрационный экзамен скоро :С
    /// <summary>
    /// Контроллер
    /// </summary>
    public class Controller
    {
        private DB.ProductServiceEntities ef; // Объявляем ентити
       
        
        /// <summary>
        /// Поле для листа из вьевера
        /// </summary>
        public DB.Products Product { get; set; }
        public List<Viewer> Viewers { get; set; } //                    << ----------   |
        public Controller()
        {
            ///
            ef = new DB.ProductServiceEntities();  // ИНИЦИАЛИЗАЦИЯ ентити
            List<DB.Products> list = ef.Products.ToList();   ///     <---
            Viewers = new List<Viewer>(); //                            |
            //                                                          |
            // Перебираем каждую коллекцию                              |
            foreach (var item in list)  // list --->      ------------->|
            {
                var s = new Viewer(item);
                Viewers.Add(s); // Добавляем в поле Viewers ---> в самом вверх         >> вверх
            }
        }

        public Controller(Viewer viewer)
        {
            ef = new DB.ProductServiceEntities();
            Product = ef.Products.Find(viewer.IdProduct);
            /*  Product = ef.Products.Where(x => x.Title == viewer.Title).First(); */
        }

        public Controller(DB.Products products)
        {
            ef = new DB.ProductServiceEntities();
            Product = products;
        }


        public void AddProduct()
        {
            ef.Products.AddOrUpdate(Product);
            ef.SaveChanges();
        }

        public void Delete()
        {         
            ef.Products.Remove(Product);
            ef.SaveChanges();
        }
        
    }
}
