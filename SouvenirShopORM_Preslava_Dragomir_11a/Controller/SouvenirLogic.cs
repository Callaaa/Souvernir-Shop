using ORMSouvenirShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORMSouvenirShop.Controller
{
    public class SouvenirLogic
    {
        private SouvenirContext _context = new SouvenirContext();
        public Souvenir Get(int id)
        {
            Souvenir findedSouvenir = _context.Souvenirs.Find(id);
            if (findedSouvenir != null)
            {
                _context.Entry(findedSouvenir).Reference(x => x.SouvenirTypes).Load();
            }
            return findedSouvenir;
        }
        public List<Souvenir> GetAll()
        {
            return _context.Souvenirs.Include("SouvenirTypes").ToList();
        }
        public void Create(Souvenir souvenir)
        {
            _context.Souvenirs.Add(souvenir);
            _context.SaveChanges();
        }
        public void Update(int id, Souvenir souvenir)
        {
            Souvenir findedSouvenir = _context.Souvenirs.Find(id);
            if (findedSouvenir == null)
            {
                return;
            }
            findedSouvenir.Name = souvenir.Name;
            findedSouvenir.SouvenirTypeId = souvenir.SouvenirTypeId;
            findedSouvenir.Description = souvenir.Description;
            findedSouvenir.Price = souvenir.Price;
            MessageBox.Show("Направихте обновяване!", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            Souvenir findedSouvenir = _context.Souvenirs.Find(id);
            _context.Souvenirs.Remove(findedSouvenir);
            MessageBox.Show("Изтрихте запис!", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            _context.SaveChanges();
        }
    }
}
