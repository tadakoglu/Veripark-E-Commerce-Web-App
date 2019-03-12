using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace BilgiAlani.Varliklar
{
    public class Product
    {
        //Veritabanı varlığı olarak kullanıldığından türkçe Ürün ismi yerine Product kullanılmıştır. Ürün kullanıldığında Code-First Entity Framework anlayışında Ürüns'e modelleme yapıyor, vesaire işlemleri otomatikleştirmek için İngilizce isim kullanıldı.
        [Key]
        public int UrunID { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public decimal Fiyat { get; set; }
        public string Kategori { get; set; }
        public byte[] ResimVerisi { get; set; }
        public string ResimMimeTipi { get; set; }
    }
}
