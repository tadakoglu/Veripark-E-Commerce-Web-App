using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebArayuz
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.RouteExistingFiles = true;
            routes.MapRoute(name: "Özel Yönlendirme", url: "{default}.aspx", defaults: new { controller = "Urun", action = "Listele", sayfa = 1 });
            // Burada Web uygulaması için bir adres yönlendirme mekanizması gerçekleştirildi.
            routes.MapRoute(null,"",new {controller = "Urun", action = "Listele", kategori = (string)null, sayfa = 1});
            routes.MapRoute(null, "Sayfa{sayfa}", new { controller = "Urun", action = "Listele", kategori = (string)null }, new { sayfa = @"\d+" });
            routes.MapRoute(null, "{kategori}", new { controller = "Urun", action = "Listele", sayfa = 1 }); 
            routes.MapRoute(null, "{kategori}/Sayfa{sayfa}", new { controller = "Urun", action = "Listele" }, new { sayfa = @"\d+" });// bknz. reg. expr.
            routes.MapRoute(null, "{controller}/{action}");
            //default.aspx dizinine gidildiğinde ürün listelenmesi için yönlendirme yapar yani ana sayfaya döner.
            
        
        }
    }
}