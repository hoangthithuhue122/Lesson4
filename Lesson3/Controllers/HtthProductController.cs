using Htthlesson3.Models;
using Humanizer;
using Microsoft.AspNetCore.Mvc;

namespace Htthlesson3.Controllers
{
    public class HtthProductController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.product = "Chuyển product thông qua ViewBag";
            ViewData["productVD"] = "Chuyển product thông qua ViewData";
            TempData["productTD"] = "Chuyển product thông qua TempData";
            return View();

        }
        public IActionResult GetAllProduct()
        {
            ViewBag.hello = "Hello Hoang Thi Thu Hue";
            //tao mock data
            HtthProduct htthProduct = new HtthProduct()
            {
                productId = 1,
                productName = "Iphone",
                price = 1200,
                quantity = 100
            };
            ViewData["htthProduct"] = htthProduct;
            var products = new List<HtthProduct>
            {
                new HtthProduct { productId = 1, productName = "iPhone 15 Pro Max", price = 1200.0, quantity = 50 },
                new HtthProduct { productId = 2, productName = "Samsung Galaxy S24 Ultra", price = 1150.0, quantity = 45 },
                new HtthProduct { productId = 3, productName = "MacBook Pro M3", price = 1999.0, quantity = 30 },
                new HtthProduct { productId = 4, productName = "Dell XPS 15", price = 1500.0, quantity = 25 },
                new HtthProduct { productId = 5, productName = "iPad Pro 11 inch", price = 799.0, quantity = 60 },
                new HtthProduct { productId = 6, productName = "Apple Watch Series 9", price = 399.0, quantity = 100 },
                new HtthProduct { productId = 7, productName = "AirPods Pro 2", price = 249.0, quantity = 120 },
                new HtthProduct { productId = 8, productName = "Sony WH-1000XM5", price = 348.0, quantity = 40 },
                new HtthProduct { productId = 9, productName = "Asus ROG Zephyrus G14", price = 1450.0, quantity = 20 },
                new HtthProduct { productId = 10, productName = "Nintendo Switch OLED", price = 349.0, quantity = 80 }
            };

            ViewData["list-product"] = products;
            return View("ListProduct");
        }
    }
}
