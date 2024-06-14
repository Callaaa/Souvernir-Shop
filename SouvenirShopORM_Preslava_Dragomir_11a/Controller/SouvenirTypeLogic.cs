using ORMSouvenirShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMSouvenirShop.Controller
{
    public class SouvenirTypeLogic
    {
        private SouvenirContext _context = new SouvenirContext();
        public List<SouvenirType> GetAllTypes()
        {
            return _context.SouvenirTypes.ToList();
        }
        public string GetSouvenirTypeById(int id)
        {
            return _context.SouvenirTypes.Find(id).Name;
        }
    }
}
