using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BilgiAlani.Soyut;
using BilgiAlani.Varliklar;
using Moq;
using WebArayuz.Controllers;
using System.Collections.Generic;
using WebArayuz.Models;
using System.Web.Mvc;
using WebArayuz.HTMLYardimcilari;

namespace BirimTestler
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SayfalayiciViewModelGonderiliyorMu() {
            // Arrange
            Mock<IUrunDeposu> mock = new Mock<IUrunDeposu>();
            mock.Setup(m => m.Urunler).Returns(new Product[] {
            new Product {UrunID = 1, Ad = "P1"},
            new Product {UrunID = 2, Ad = "P2"},
            new Product {UrunID = 3, Ad = "P3"},
            new Product {UrunID = 4, Ad = "P4"},
            new Product {UrunID = 5, Ad = "P5"}
            });
            // Arrange
            UrunController controller = new UrunController(mock.Object);
            controller.SayfabasiUrunSayisi = 3;
            // Act
            UrunListelemeViewModel result = (UrunListelemeViewModel)controller.Listele(null, 2).Model;
            // Assert
            SayfalamaBilgisi pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2); // 2'ye eşit mi ?
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }

        [TestMethod]
        public void SayfalamaYapiyorMu()
        {
           //Test iptal edildi
            // Arrange
            Mock<IUrunDeposu> mock = new Mock<IUrunDeposu>();
            mock.Setup(m => m.Urunler).Returns(new Product[] {
            new Product {UrunID = 1, Ad = "P1"},
            new Product {UrunID = 2, Ad = "P2"},
            new Product {UrunID = 3, Ad = "P3"},
            new Product {UrunID = 4, Ad = "P4"},
            new Product {UrunID = 5, Ad = "P5"}
            });
            UrunController controller = new UrunController(mock.Object);
            controller.SayfabasiUrunSayisi = 3;
            // Act
            //IEnumerable<Product> result =   (IEnumerable<Product>)controller.Listele(2).Model;
       
            UrunListelemeViewModel result= (UrunListelemeViewModel)controller.Listele(null, 2).Model;
            //Assert
            //Product[] prodArray = result.ToArray();
            //Assert.IsTrue(prodArray.Length == 2);
            //Assert.AreEqual(prodArray[0].Ad , "P4");
            //Assert.AreEqual(prodArray[1].Ad, "P5");
        }
        [TestMethod]
        public void SayfaLinkleriOlusturuluyorMu() 
        {
            // Arrange - düzenleme
            // 
            HtmlHelper myHelper = null;
            // Arrange - örnek bi sayfalama verisi oluşturdum
            SayfalamaBilgisi pagingInfo = new SayfalamaBilgisi 
            {
            CurrentPage = 2,
            TotalItems = 28,
            ItemsPerPage = 10
            };

            // Arrange - lambda ifadesi ile delegate'a atama yaptım
            Func<int, string> pageUrlDelegate = i => "Page" + i;
            // Act
            MvcHtmlString result = myHelper.SayfaLinkleri(pagingInfo, pageUrlDelegate);
            // Assert - teyit et
            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
            + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
            + @"<a class=""btn btn-default"" href=""Page3"">3</a>",
            result.ToString());
        }
    }
}
