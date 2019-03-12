using BilgiAlani.Soyut;
using BilgiAlani.Varliklar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebArayuz.Models;
namespace WebArayuz.Controllers
{
    public class SepetController : Controller
    {
        //
        // GET: /Sepet/

        private IUrunDeposu depo;
            public SepetController(IUrunDeposu depo)
            {
                this.depo = depo;
            }
            public ViewResult AlisverisiTamamla()
            {
                return View(new GonderimDetaylari());

            }
            [HttpPost]
            public ViewResult AlisverisiTamamla(Cart cart, GonderimDetaylari gonderimDetaylari)
            {
                
                if (cart.Lines.Count() == 0)
                {
                    ModelState.AddModelError("", "Üzgünüz, sepetiniz boş.");
                }
                if (ModelState.IsValid) // modelimiz geçerliyse yani kullanıcı uygun adres bilgilerini ve ismini yazdıysa siparişi alalım.
                {
                    depo.SiparisiVeritabaninaYaz(cart, User.Identity, gonderimDetaylari); // VERİTABANINA YAZ
                    
                    cart.Clear(); // Burası sepetin içeriğini temizler
                    return View("SiparisVerildi");
                }
                else
                {
                    return View(gonderimDetaylari);
                }
            }
            public PartialViewResult SepetOzeti(Cart sepet)
            {
                return PartialView(sepet);
            }
            public ViewResult Index(Cart sepet, string returnUrl)
            {
                return View(new SepetIcindekilerViewModel { Cart = sepet, ReturnUrl = returnUrl });
            }
            //Model bağlayıcı kullanıldığından iptal edildi
            //private Cart GetCart() // Kişiye özel oturumun daha önce oluşturulup olup olmamasına göre veri döndürür.
            //{
            //    Cart cart = (Cart)Session["Sepetim"];  // Sepetim ID'li oturumdaki veriyi kontrol et.
            //    if (cart == null)
            //    {
            //        cart = new Cart();
            //        Session["Sepetim"] = cart; // Sepetim ID'li oturumdaki veriyi doldur.
            //    }
            //    return cart;
            //}
            public RedirectToRouteResult SepeteEkle(Cart sepet, int UrunID, string returnUrl, string KacAdet="1") //Dönüş adresi UrunOzeti.cshtml dosyasından elde edilir, bu metot oradan çağrılmıştır.
            {
                int adet;
                try
                {
                    adet = int.Parse(KacAdet);
                    if (adet == 0 || adet < 0)
                    {
                        adet = 1;
                    }

                    Product urun = depo.Urunler.FirstOrDefault(p => p.UrunID == UrunID);

                    if (urun != null)
                    {
                        sepet.AddItem(urun, adet);
                    }
                    return RedirectToAction("Index", new { returnUrl }); //Burası işlem yapıldıktan sonra sepete yönlendirme sağlar.
                }
                catch // tam sayı gönderilmemişsse işlem yapmaz olduğu yere geri döner
                {
                    return RedirectToAction("UruneGit", "Urun", new { UrunID });
                }
               
                
            }

            public RedirectToRouteResult RemoveFromCart(Cart sepet, int UrunID, string returnUrl)
            {
            Product product = depo.Urunler.FirstOrDefault(p => p.UrunID == UrunID);
            if (product != null) 
            {
            sepet.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
            }
            

    }
}
