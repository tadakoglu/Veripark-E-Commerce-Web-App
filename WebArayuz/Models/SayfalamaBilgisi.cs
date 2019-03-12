using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebArayuz.Models
{
    public class SayfalamaBilgisi
    {
        //BU BİR VİEW MODEL'DİR BİLGİ ALANI MODELERİNDEN UZAK BİR BÖLÜM OLAN MODELSDE TUTULMUŞTUR.
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); }
        }
    }
}