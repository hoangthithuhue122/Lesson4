using Microsoft.AspNetCore.Mvc;
using HtthDemoBaiGiang04.Models;

namespace HtthDemoBaiGiang04.Controllers
{
    public class HtthProductController : Controller
    {
        public IActionResult Index()
        {
            //tao 1 sp
            var product = new HtthProduct()
            {
                productId = "SP001",
                productName = "lenovo",
                quantity = 10,
                price = 15000
            };

            ViewBag.ProductVB = product;
            ViewData["ProductVD"] = product;

            return View();
        }
        public IActionResult getAllProducts()
        {
            //tao mock data
            List<HtthProduct> products = new List<HtthProduct>()
            {
                new HtthProduct { productId = "P01", productName = "Laptop Dell Inspiron", quantity = 15, price = 15500000m },
                new HtthProduct { productId = "P02", productName = "Chuột không dây Logitech", quantity = 50, price = 350000m },
                new HtthProduct { productId = "P03", productName = "Bàn phím cơ Gaming", quantity = 30, price = 1200000m },
                new HtthProduct { productId = "P04", productName = "Màn hình LG 27 inch", quantity = 12, price = 4800000m },
                new HtthProduct { productId = "P05", productName = "Tai nghe Bluetooth Sony", quantity = 25, price = 2100000m },
                new HtthProduct { productId = "P06", productName = "Balo đựng laptop", quantity = 40, price = 450000m },
                new HtthProduct { productId = "P07", productName = "Ổ cứng SSD Kingston 512GB", quantity = 20, price = 1150000m },
                new HtthProduct { productId = "P08", productName = "USB Sandisk 64GB", quantity = 60, price = 180000m },
                new HtthProduct { productId = "P09", productName = " Đế tản nhiệt laptop", quantity = 35, price = 250000m },
                new HtthProduct { productId = "P10", productName = "Webcam Full HD 1080p", quantity = 18, price = 850000m }
            };

            //luu vao doi tuonf viewdta de chuyen len view
            ViewData["products"] = products;
            return View("Products");
        }

    }
}
