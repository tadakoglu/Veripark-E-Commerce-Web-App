using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace BilgiAlani.Varliklar
{
    public class BoughtByUser
    {
        [Key]
        [Column(Order = 0)]
        public string WindowsKimligi { get; set; }
        [Key]
        [Column(Order = 1)]
        public int UrunID { get; set; }
        public int Sayisi { get; set; }
        public string GonderilecekAdres { get; set; }
        public string GonderilecekKisiAdi { get; set; }
        public bool HediyePakediMi { get; set; }
        
    }
}
