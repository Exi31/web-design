using Microsoft.AspNetCore.Mvc;
using NTM_Lab03.Models;
using System.Diagnostics;

namespace NTM_Lab03.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Product> products = new List<Product>
    {
        new Product
        {
            Id = 1,
            Name = "Áo bóng đá Real Madrid sân nhà mùa giải 2011/12",
            Image = "/images/product/1112 home.webp",
            Price = 2000000
        },

        new Product
        {
            Id = 2,
            Name = "Áo bóng đá Real Madrid sân khách mùa giải 2011/12",
            Image = "/images/product/1112 away.webp",
            Price = 2000000
        },

        new Product
        {
            Id = 3,
            Name = "Áo bóng đá Real Madrid thứ ba mùa giải 2011/12",
            Image = "/images/product/1112 3rd.webp",
            Price = 2000000
        }
    };

            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
