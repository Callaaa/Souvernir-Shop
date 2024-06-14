using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMSouvenirShop.Model
{
    public class Souvenir
    {
        // Уникален идентификатор на сувенира
        public int Id { get; set; }
        // Име на сувенира
        public string Name { get; set; }
        // Описание на сувенира
        public string Description { get; set; }
        // Цена на сувенира
        public double Price { get; set; }
        // Идентификатор на типа сувенир (външен ключ)
        public int SouvenirTypeId { get; set; }
        // Таблицата, с която се осъществява връзката
        // Връзка М:1
        public SouvenirType SouvenirTypes { get; set; }
    }
}
