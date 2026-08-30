using Microsoft.AspNetCore.Mvc;
using NTM_Lab02.Models;

namespace NTM_Lab02.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index(int categoryId = 0)
        {
            List<Category> categories = GetCategories();
            List<Product> products = GetProducts();

            if (categoryId != 0)
            {
                List<Product> filteredProducts = new List<Product>();

                foreach (Product product in products)
                {
                    if (product.CategoryId == categoryId)
                    {
                        filteredProducts.Add(product);
                    }
                }

                products = filteredProducts;
            }

            ViewBag.Categories = categories;
            ViewBag.Products = products;

            return View();
        }

        public IActionResult Detail(int id)
        {
            List<Product> products = GetProducts();

            Product product = new Product();
            bool found = false;

            foreach (Product item in products)
            {
                if (item.Id == id)
                {
                    product = item;
                    found = true;
                    break;
                }
            }

            if (found == false)
            {
                return NotFound();
            }

            ViewBag.Product = product;

            return View();
        }

        private List<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category { Id = 1, Name = "Quần áo" },
                new Category { Id = 2, Name = "Túi xách" },
                new Category { Id = 3, Name = "Đồng hồ" },
                new Category { Id = 4, Name = "Ti vi" },
                new Category { Id = 5, Name = "Tủ lạnh" },
                new Category { Id = 6, Name = "Máy bơm" },
                new Category { Id = 7, Name = "Quạt điện" },
                new Category { Id = 8, Name = "Lò sưởi" }
            };
        }

        private List<Product> GetProducts()
        {
            return new List<Product>
    {
        new Product
        {
            Id = 1,
            Name = "Real Madrid 2011/12 Home Kit",
            Image = "~/images/products/1112 home.webp",
            Price = 500000,
            SalePrice = 350000,
            CategoryId = 1,
            Description = "Bộ quần áo sân nhà của Real Madrid mùa giải 2011/12.",
            Status = 1,
            CreatedAt = new DateTime(2026, 8, 30)
        },

        new Product
        {
            Id = 2,
            Name = "Real Madrid 2011/12 Away Kit",
            Image = "~/images/products/1112 away.webp",
            Price = 500000,
            SalePrice = 350000,
            CategoryId = 1,
            Description = "Bộ quần áo sân khách của Real Madrid mùa giải 2011/12.",
            Status = 1,
            CreatedAt = new DateTime(2026, 8, 30)
        },

        new Product
        {
            Id = 3,
            Name = "Real Madrid 2011/12 Third Kit",
            Image = "~/images/products/1112 3rd.webp",
            Price = 500000,
            SalePrice = 350000,
            CategoryId = 1,
            Description = "Bộ quần áo thứ ba của Real Madrid mùa giải 2011/12.",
            Status = 1,
            CreatedAt = new DateTime(2026, 8, 30)
        },

        new Product
        {
            Id = 4,
            Name = "Real Madrid 2016/17 Home Kit",
            Image = "~/images/products/1617 home.webp",
            Price = 500000,
            SalePrice = 350000,
            CategoryId = 1,
            Description = "Bộ quần áo sân nhà của Real Madrid mùa giải 2016/17.",
            Status = 1,
            CreatedAt = new DateTime(2026, 8, 30)
        },

        new Product
        {
            Id = 5,
            Name = "Real Madrid 2016/17 Away Kit",
            Image = "~/images/products/1617 away.webp",
            Price = 500000,
            SalePrice = 350000,
            CategoryId = 1,
            Description = "Bộ quần áo sân khách của Real Madrid mùa giải 2016/17.",
            Status = 1,
            CreatedAt = new DateTime(2026, 8, 30)
        },

        new Product
        {
            Id = 6,
            Name = "Real Madrid 2016/17 Third Kit",
            Image = "~/images/products/1617 3rd.jpg",
            Price = 500000,
            SalePrice = 350000,
            CategoryId = 1,
            Description = "Bộ quần áo thứ ba của Real Madrid mùa giải 2016/17.",
            Status = 1,
            CreatedAt = new DateTime(2026, 8, 30)
        }
    };
        }
    }
}
