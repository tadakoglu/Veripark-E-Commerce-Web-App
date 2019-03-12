using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilgiAlani.Soyut;
using BilgiAlani.Varliklar;
using BilgiAlani.Somut;
using WebArayuz.Models;
namespace WebArayuz.Controllers
{
    public class UrunController : Controller
    {
        //
        // GET: /Urun/

        private IUrunDeposu depo;
        public int SayfabasiUrunSayisi = 7;
        public UrunController(IUrunDeposu urunDeposu)
        {
            this.depo = urunDeposu;
        }
        //Sayfa başı 7 tane ürün gösterilir.
        public ViewResult Listele(string kategori, int sayfa = 1)
        {
            //return View(depo.Urunler.OrderBy(p => p.UrunID).Skip((page - 1) * SayfabasiUrunSayisi).Take(SayfabasiUrunSayisi), 
            //    SayfalamaBilgisi = new SayfalamaBilgisi
            //{
            //    CurrentPage = page,
            //    ItemsPerPage = SayfabasiUrunSayisi,
            //    TotalItems = depo.Urunler.Count()
            //});
            
            UrunListelemeViewModel model = new UrunListelemeViewModel
            {
                //Şimdi ürünleri alfabetik olarak sıralayayım
                Products = depo.Urunler.Where(p => kategori == null || p.Kategori == kategori).OrderBy(p => p.Ad).Skip((sayfa - 1) * SayfabasiUrunSayisi).Take(SayfabasiUrunSayisi),
                PagingInfo = new SayfalamaBilgisi
                {
                    CurrentPage = sayfa,
                    ItemsPerPage = SayfabasiUrunSayisi,
                    TotalItems = kategori == null ?
                        depo.Urunler.Count() :
                        depo.Urunler.Where(e => e.Kategori == kategori).Count()
                },
                CurrentCategory = kategori
            }; 
            return View(model);
        }
        public ViewResult Ara(string AramaKutusu)
        {
            IEnumerable<Product> Products = depo.Urunler.Where(u => u.Ad.ToLower().Contains(AramaKutusu.ToLower()) || u.Aciklama.ToLower().Contains(AramaKutusu.ToLower()) || u.Kategori.ToLower().Contains(AramaKutusu.ToLower())).OrderBy(p => p.Ad);                
            
            return View(Products);
        }
        public ViewResult UruneGit(int UrunID) // ürün detaylarını görüntüler
        {
            Product p = depo.Urunler.First(x => x.UrunID == UrunID);
            ViewBag.KacDefaSatinAlinmis = depo.SiparisVerilenler.Where(urun => urun.UrunID == UrunID).Sum(u => u.Sayisi);
            return View(p);
        }
        public FileContentResult ResmiGetir(int urunId)
        {
            Product prod = depo.Urunler.FirstOrDefault(p => p.UrunID == urunId);
            if (prod != null)
            {
                return File(prod.ResimVerisi, prod.ResimMimeTipi);
            }
            else
            {
                return null;
            }
        }
    }
}
