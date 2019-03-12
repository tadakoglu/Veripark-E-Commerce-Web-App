using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations; // VERİ DOĞRULAMA ( VALIDATION ) YAPACAĞIM

namespace BilgiAlani.Varliklar
{
    public class GonderimDetaylari
    {
        [Display(Name="Ad*")]
        [Required(ErrorMessage = "Lütfen isminizi giriniz.")]
        public string Name { get; set; }

        [Display(Name = "Adres 1*")]
        [Required(ErrorMessage = "Lütfen ilk adres satırını doldurunuz.")]
        public string Line1 { get; set; }

        [Display(Name = "Adres 2")]
        public string Line2 { get; set; }

        [Display(Name = "Adres 3")]
        public string Line3 { get; set; }

        [Display(Name = "Şehir*")]
        [Required(ErrorMessage = "Lütfen bir şehir adı giriniz")]
        public string City { get; set; }

        [Display(Name = "Bölge ya da Eyalet*")]
        [Required(ErrorMessage = "Lütfen gönderilecek bölgeyi yazınız belirleyiniz")]
        public string State { get; set; }

        [Display(Name = "Posta Kodu")]
        public string Zip { get; set; }

        [Display(Name = "Ülke*")]
        [Required(ErrorMessage = "Lütfen ülke adını yazınız")]
        public string Country { get; set; }
        public bool GiftWrap
        {
            get;
            set;    
        }
    }
}
