using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMSouvenirShop.Model
{
    public class SouvenirContext : DbContext
    {
        // Конструктор на класа SouvenirContext, който извиква
        // базовия конструктор с името на връзката към базата данни
        public SouvenirContext() : base("SouvenirContext")
        {

        }
        // Превръща набор от данни в таблица 
        public DbSet<Souvenir> Souvenirs { get; set; }
        // Превръща набор от данни в таблица 
        public DbSet<SouvenirType> SouvenirTypes { get; set; }
    }
}
