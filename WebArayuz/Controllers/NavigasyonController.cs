using BilgiAlani.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebArayuz.Controllers
{
    public class NavigasyonController : Controller
    {
        //
        // GET: /Navigasyon/
        private IUrunDeposu depo;
        public NavigasyonController(IUrunDeposu depo)
        {
            this.depo = depo;
        }
        //Buradaki kategori değişkeninin içeriği yönlendirme mekanizmasındaki kategori değişkeninden elde edilir.
        //Buradaki metot, _Layout.cshtml dosyasındaki Html.Action metodu ile çağrılmıştır, değişken bilgisi de o sayfa varolan bilgiden alınır.
        public PartialViewResult Menu(string kategori= null) 
        {
            ViewBag.SeciliKategori = kategori;
            IEnumerable<string> TumKategoriler = depo.Urunler.Select(x => x.Kategori).Distinct().OrderBy(x => x);
            return PartialView(TumKategoriler);
        }
        public PartialViewResult DropdownMenu(string kategori = null)
        {
            
            IEnumerable<string> TumKategoriler = depo.Urunler.Select(x => x.Kategori).Distinct().OrderBy(x => x);
            ViewBag.SeciliKategori = kategori;
            return PartialView(TumKategoriler);
        }


    }
}
