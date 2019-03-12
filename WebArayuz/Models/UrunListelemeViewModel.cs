using BilgiAlani.Varliklar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebArayuz.Models
{
    public class UrunListelemeViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public SayfalamaBilgisi PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}