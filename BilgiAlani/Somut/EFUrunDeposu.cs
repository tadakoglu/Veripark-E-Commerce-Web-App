using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BilgiAlani.Soyut;
using BilgiAlani.Varliklar;

namespace BilgiAlani.Somut
{
    public class EFUrunDeposu : IUrunDeposu
    {
        private EFDBIcerik icerik = new EFDBIcerik();
        public IEnumerable<Product> Urunler
        {
            get { return icerik.Products; }
        }

        //ürün daha önce alındıysa yani windowkimligi ve urunid aynı olan başka urun varsa sadece sayısını arttır

       
        public bool SiparisiVeritabaninaYaz(Cart cart, System.Security.Principal.IIdentity WindowsKimligi, GonderimDetaylari gonderimDetaylari)
        {

            IEnumerable<CartLine> satinAlinanlar = cart.Lines;
            foreach (CartLine item in satinAlinanlar)
            {
                BoughtByUser kontrol = icerik.BoughtByUsers.Find(WindowsKimligi.Name, item.Product.UrunID);
                if (kontrol == null) // ürün daha önce alınmamışssa
                {
                    BoughtByUser eklenecek = new BoughtByUser { WindowsKimligi = WindowsKimligi.Name, Sayisi = item.Quantity, UrunID = item.Product.UrunID, GonderilecekAdres=gonderimDetaylari.Line1 + " " + gonderimDetaylari.Line2 + " " + gonderimDetaylari.Line3 + "/" + gonderimDetaylari.City + "/" + gonderimDetaylari.State + "/" + gonderimDetaylari.Country, GonderilecekKisiAdi=gonderimDetaylari.Name, HediyePakediMi= gonderimDetaylari.GiftWrap};
                    icerik.BoughtByUsers.Add(eklenecek);
                }
                else
                {
                    kontrol.Sayisi = item.Quantity + kontrol.Sayisi;
                     //daha önce alınmışssa sadece miktarını arttır
                }
            }
            try
            {
                icerik.SaveChanges();
                
            }
            catch
            {
                return false;
            }
            return true;
            
        }


        public IEnumerable<BoughtByUser> SiparisVerilenler
        {
            get { return icerik.BoughtByUsers; }
        }
    }
}
