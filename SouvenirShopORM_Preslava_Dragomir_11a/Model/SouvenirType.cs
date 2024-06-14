using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMSouvenirShop.Model
{
    public class SouvenirType
    {
        // Уникален идентификатор на типа сувенир
        public int Id { get; set; }
        // Име на типа сувенир
        public string Name { get; set; }
        // Създаване на колекция сувенири с тип Souvenir
        public ICollection<Souvenir> Souvenirs { get; set; }
    }
}
