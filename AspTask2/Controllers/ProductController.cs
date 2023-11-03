using AspTask2.Entities;
using AspTask2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AspTask2.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            List<Product> products = new List<Product>()
            {
                new Product {
                    Id = 1,
                     Name="oreo",
                      Desciption="~/Images/coffee.jpg",
                       Price=4.50,
                       Discount=1
                },
                new Product {
                    Id = 2,
                     Name="oreo",
                      Desciption="~/Images/coffee.jpg",
                       Price=4.50,
                       Discount=1
                },
                new Product {
                    Id = 2,
                     Name="oreo",
                      Desciption="~/Images/coffee.jpg",
                       Price=4.50,
                       Discount=1
                },
                new Product {
                    Id = 2,
                     Name="oreo",
                      Desciption="~/Images/coffee.jpg",
                       Price=4.50,
                       Discount=1
                },
            };
            ProductViewModel viewModel = new ProductViewModel();
            viewModel.Products = products;
            return View(viewModel);
        }
    }
}
