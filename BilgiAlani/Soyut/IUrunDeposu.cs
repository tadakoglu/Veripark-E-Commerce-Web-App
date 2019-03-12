using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BilgiAlani.Varliklar;
using BilgiAlani.Somut;

namespace BilgiAlani.Soyut
{
    public interface IUrunDeposu
    {
        IEnumerable<Product> Urunler
        {
            get;
        }
        IEnumerable<BoughtByUser> SiparisVerilenler
        {
            get;
        }
        bool SiparisiVeritabaninaYaz(Cart cart, System.Security.Principal.IIdentity WindowsKimligi, GonderimDetaylari gonderimDetaylari);
    }
}
