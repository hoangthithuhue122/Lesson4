using Microsoft.AspNetCore.Mvc;
using HtthDay03.Models;

namespace HtthDay03.Controllers
{
    public class ProductController : Controller
    {
        private readonly List<Category> _categories = new List<Category>
        {
            new Category { Id = 1, Name = "Quần áo" },
            new Category { Id = 2, Name = "Túi xách" },
            new Category { Id = 3, Name = "Đồng hồ" },
            new Category { Id = 4, Name = "Tivi" },
            new Category { Id = 5, Name = "Tủ lạnh" },
            new Category { Id = 6, Name = "Máy bơm" },
            new Category { Id = 7, Name = "Quạt điện" },
            new Category { Id = 8, Name = "Lò sưởi" },
        };
        private readonly List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Bộ đồ bơi cho trẻ em nam", Image = "/images/Avatar/doboinam.png", Price = 50000, salePrice = 35000, CategoryId = 1, Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Ipsa eligendi, voluptatem perspiciatis qui delectus ab unde lure dolorum natus expedita, laborum blanditiis quaerat repellendus necessitatibus nam quo earum ex suscipit.", Status = true, CreatedAt = new DateTime(2021,7,15,12,0,0) },
            new Product { Id = 2, Name = "Bộ đồ bơi cho trẻ em nữ", Image = "/images/Avatar/doboinu.png", Price = 50000, salePrice = 35000, CategoryId = 1, Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Ipsa eligendi, voluptatem perspiciatis qui delectus ab unde lure dolorum natus expedita, laborum blanditiis quaerat repellendus necessitatibus nam quo earum ex suscipit.", Status = true, CreatedAt = new DateTime(2021,7,15,12,0,0) },
            new Product { Id = 3, Name = "Bộ đồ bơi cho trẻ em từ 3-5 tuổi", Image = "/images/Avatar/dotrenho.png", Price = 50000, salePrice = 35000, CategoryId = 1, Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Ipsa eligendi, voluptatem perspiciatis qui delectus ab unde lure dolorum natus expedita, laborum blanditiis quaerat repellendus necessitatibus nam quo earum ex suscipit.", Status = true, CreatedAt = new DateTime(2021,7,15,12,0,0) },
            new Product { Id = 4, Name = "Bộ đồ bơi cho trẻ em thời trang", Image = "/images/Avatar/dothoitrang.png", Price = 50000, salePrice = 35000, CategoryId = 1, Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Ipsa eligendi, voluptatem perspiciatis qui delectus ab unde lure dolorum natus expedita, laborum blanditiis quaerat repellendus necessitatibus nam quo earum ex suscipit.", Status = true, CreatedAt = new DateTime(2021,7,15,12,0,0) },
            new Product { Id = 5, Name = "Túi thời trang mẫu mới 2021", Image = "/images/Avatar/tui2021.png", Price = 50000, salePrice = 35000, CategoryId = 2, Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Ipsa eligendi, voluptatem perspiciatis qui delectus ab unde lure dolorum natus expedita, laborum blanditiis quaerat repellendus necessitatibus nam quo earum ex suscipit.", Status = true, CreatedAt = new DateTime(2021, 7, 15, 12, 0, 0) },
            new Product { Id = 5, Name = "Túi thời trang da cá sấu", Image = "/images/Avatar/tuicasau.png", Price = 50000, salePrice = 35000, CategoryId = 2, Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Ipsa eligendi, voluptatem perspiciatis qui delectus ab unde lure dolorum natus expedita, laborum blanditiis quaerat repellendus necessitatibus nam quo earum ex suscipit.", Status = true, CreatedAt = new DateTime(2021,7,15,12,0,0) },
        };

        public IActionResult Index(int? id)
        {
            var products = _products;
            if (id.HasValue)
            {
                products = products.Where(p => p.CategoryId == id.Value).ToList();
            }
            ViewBag.Categories = _categories;
            return View(products);
        }
        public IActionResult Detail(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}
