using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Entity;
using BilgiAlani.Varliklar;

namespace BilgiAlani.Somut
{
    public class EFDBIcerik : DbContext
    {
        // BURADA TÜRKÇE İSİMLER KULLANILIRSA 'S' TAKILLARI İLE İLİŞKİLİ BİR VERİ TABANI HATASI OLUŞUYOR.
        public DbSet<Product> Products { get; set; }
        public DbSet<BoughtByUser> BoughtByUsers { get; set; }
       
    }
}
