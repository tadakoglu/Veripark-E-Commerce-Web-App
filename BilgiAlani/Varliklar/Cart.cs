using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BilgiAlani.Varliklar
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        public void AddItem(Product product, int quantity)
        {
            CartLine line = lineCollection.Where(p => p.Product.UrunID == product.UrunID).FirstOrDefault();
            if (line == null) // böyle bir ürün yoksa
            {
                lineCollection.Add(new CartLine  {    Product = product, Quantity = quantity    });
            }
            else
            {
                line.Quantity += quantity; // böyle bi ürün varsa sadece sayısını arttır
            }
        }
        public void RemoveLine(Product product) // sepetten ürün sil
        {
            lineCollection.RemoveAll(l => l.Product.UrunID == product.UrunID);
        }
        public decimal ComputeTotalValue() // toplam alışveriş sepeti fiyatını hesapla.
        {
            return lineCollection.Sum(e => e.Product.Fiyat * e.Quantity);
        }
        public void Clear()
        {
            lineCollection.Clear();
        }
        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }
}
