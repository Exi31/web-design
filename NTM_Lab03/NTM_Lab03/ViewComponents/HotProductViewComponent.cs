using Microsoft.AspNetCore.Mvc;
using NTM_Lab03.Models;

namespace NTM_Lab03.ViewComponents
{
    public class HotProductViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<Product> products = new List<Product>
            {
                new Product
                {
                    Id = 4,
                    Name = "Áo bóng đá Real Madrid sân nhà mùa giải 2016/17",
                    Image = "/images/product/1617 home.webp",
                    Price = 2000000
                },

                new Product
                {
                    Id = 5,
                    Name = "Áo bóng đá Real Madrid sân khách mùa giải 2016/17",
                    Image = "/images/product/1617 away.webp",
                    Price = 2000000
                },

                new Product
                {
                    Id = 6,
                    Name = "Áo bóng đá Real Madrid thứ ba mùa giải 2016/17",
                    Image = "/images/product/1617 3rd.jpg",
                    Price = 2000000
                }
            };

            return View(products);
        }
    }
}