using System;
using System.Collections.Generic;
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
        /// <summary>
        /// Поле для листа из вьевера
        /// </summary>
        public List<Viewer> Viewers { get;  set; } //                    << ----------   |


        public Controller()
        {
            ///
            var ef = new DB.ProductServiceEntities();
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
    }
}
