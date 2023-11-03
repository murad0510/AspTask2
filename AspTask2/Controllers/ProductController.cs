using AspTask2.Entities;
using AspTask2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace AspTask2.Controllers
{
    public class ProductController : Controller
    {
        static List<Product> products = new List<Product>()
            {
                new Product {
                    Id = 1,
                     Name="Oreo",
                      Desciption="https://www.foodandwine.com/thmb/CNeNoP5IFc6gMfvkZyplDv_zjv0=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/Oreo-Frozen-Treats-FT-BLOG0122-3d76bc020fa64a15a7b974a164976175.jpg",
                       Price=4.50,
                       Discount=1
                },
                new Product {
                    Id = 2,
                     Name="Magnum",
                      Desciption="https://images.squarespace-cdn.com/content/v1/568bea5540667a54498bf784/1570632444443-9DMYAO4Y4VUW6RSNZ9YD/Lux-Magnum-Food-Photography-Chocolate-Ice-Cream-1.jpg?format=1500w",
                       Price=3.50,
                       Discount=1
                },
                new Product {
                    Id = 3,
                     Name="Lays",
                      Desciption="https://www.lays.com/sites/lays.com/files/2020-11/lays-Classic-small.jpg",
                       Price=2.00,
                       Discount=1
                },
                new Product {
                    Id = 4,
                     Name="m&m's",
                      Desciption="https://cdn.media.amplience.net/i/marsmmsprod/ct2143_img_01_1000842915_4010241073_4010241074?%24i%24=&w=992",
                       Price=4.50,
                       Discount=1
                },
                new Product {
                    Id = 5,
                     Name="oreo",
                      Desciption="https://phorcys-static.ewg.org/kwikee/044/000/032/029.jpg",
                       Price=4.50,
                       Discount=1
                },
            };

        public IActionResult Index()
        {
            //id = 0;
            ProductViewModel viewModel = new ProductViewModel();
            viewModel.Products = products;
            return View(viewModel);
        }

        public IActionResult Delete(int productId)
        {
            for (int i = 0; i < products.Count; ++i)
            {
                if (products[i].Id == productId)
                {
                    products.Remove(products[i]);
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
    }
}
