using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BilgiAlani.Soyut
{
    public interface IKullaniciDeposu
    {
        //Burası iptal edildi
        bool KullaniciAdresBilgisiniYaz(System.Security.Principal.IIdentity WindowsKimligi,string Adress);
    }
}
