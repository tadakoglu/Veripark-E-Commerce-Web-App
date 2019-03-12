using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilgiAlani.Varliklar;

namespace WebArayuz.Altyapi.ModelBaglayicilar
{
    public class SepetModeliBaglayici : IModelBinder
    {
        private const string sessionKey = "Sepetim";
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // Sepet bilgisini oturumdan al
            Cart cart = null;
            if (controllerContext.HttpContext.Session != null)
            {
                cart = (Cart)controllerContext.HttpContext.Session[sessionKey]; // Session obje getirir, bunu Cart'a dönüştürürüz
            }
            // oturum verisinde herhangi bir sepet yoksa yeni bir tane oluşur.
            if (cart == null)
            {
                cart = new Cart();
                if (controllerContext.HttpContext.Session != null) // oturum nesnesinin boş olmasına karşın hata oluşmasını önle
                {
                    controllerContext.HttpContext.Session[sessionKey] = cart;
                }
            }
            // return the cart
            return cart;
        }
    }
}