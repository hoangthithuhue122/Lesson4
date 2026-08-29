using HtthLesson3.Models;
using Microsoft.AspNetCore.Mvc;

namespace HtthLesson3.Controllers
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
            HtthProduct htthProduct = new HtthProduct() { 
                productId = 1, 
                productName = "Iphone 14", 
                productPrice = 20000000, 
                quantity = 10 
            };
            ViewData["htthProduct"] = htthProduct;

            var products = new List<HtthProduct>
        {
            new HtthProduct { productId = 1, productName = "Laptop Dell Inspiron", productPrice = 15990000m, quantity = 10 },
            new HtthProduct { productId = 2, productName = "Chuột không dây Logitech", productPrice = 350000m, quantity = 50 },
            new HtthProduct { productId = 3, productName = "Bàn phím cơ Keychron", productPrice = 1850000m, quantity = 25 },
            new HtthProduct { productId = 4, productName = "Màn hình LG 27 inch", productPrice = 4200000m, quantity = 15 },
            new HtthProduct { productId = 5, productName = "Tai nghe Sony WH-1000XM4", productPrice = 5490000m, quantity = 8 },
            new HtthProduct { productId = 6, productName = "Ổ cứng SSD Samsung 1TB", productPrice = 2100000m, quantity = 30 },
            new HtthProduct { productId = 7, productName = "Balo đựng laptop", productPrice = 450000m, quantity = 40 },
            new HtthProduct { productId = 8, productName = "Sạc dự phòng Anker 20000mAh", productPrice = 890000m, quantity = 20 },
            new HtthProduct { productId = 9, productName = "Webcam Logitech C920", productPrice = 1650000m, quantity = 12 },
            new HtthProduct { productId = 10, productName = "Loa Bluetooth JBL Flip 6", productPrice = 2490000m, quantity = 18 }
        };

            ViewData["list-product"] = products;
            return View("ListProduct");
        }
    }
}
