using AspTask2.Entities;
using AspTask2.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace AspTask2.Controllers
{
    public class ProductController : Controller
    {
        static List<Product> products = new List<Product>()
            {
                new Product {
                    Id = 1,
                     Name="Oreo",
                      Desciption="OreoBigPacket.jpg",
                       Price=4.50,
                       Discount=1
                },
                new Product {
                    Id = 2,
                     Name="Magnum",
                      Desciption="Magnum.jpg",
                       Price=3.50,
                       Discount=1
                },
                new Product {
                    Id = 3,
                     Name="Lays",
                      Desciption="Lays.jpg",
                       Price=2.00,
                       Discount=0.6
                },
                new Product {
                    Id = 4,
                     Name="m&m's",
                      Desciption="M&M's.png",
                       Price=4.50,
                       Discount=0.5
                },
                new Product {
                    Id = 5,
                     Name="Pizza",
                      Desciption="Pizza.jpg",
                       Price=3.30,
                       Discount=0.4
                },
            };

        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IWebHostEnvironment env)
        {
            _webHostEnvironment = env;
        }
        public IActionResult Index()
        {
            //id = 0;
            ProductViewModel viewModel = new ProductViewModel();
            viewModel.Products = products;
            return View(viewModel);
        }

        public Product getProductById(int id)
        {
            for (int i = 0; i < products.Count; ++i)
            {
                if (products[i].Id == id)
                {
                    return products[i];
                }
            }
            return null;
        }

        public IActionResult Delete(int productId)
        {
            var data = getProductById(productId);
            if (data != null)
            {
                products.Remove(data);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int productId)
        {
            var data = getProductById(productId);
            UpdateProductViewModel viewModel = new UpdateProductViewModel();
            viewModel.Product = data;
            return View("UpdateProduct", viewModel);
        }

        //[HttpPut]
        public async Task<IActionResult> Update(UpdateProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                var product = productViewModel.Product;
                if (product != null)
                {
                    string folder = string.Empty;
                    if (product.CoverPhoto != null)
                    {
                        folder = (Guid.NewGuid() + product.CoverPhoto.FileName).ToString();
                        string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images/" + folder);

                        await product.CoverPhoto.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                    }

                    for (int i = 0; i < products.Count; i++)
                    {
                        if (products[i].Id == product.Id)
                        {
                            if (folder != string.Empty)
                            {
                                product.Desciption = folder;
                            }
                            else
                            {
                                product.Desciption = products[i].Desciption;
                            }

                            products[i] = product;
                            break;
                        }
                    }
                }
                return RedirectToAction("Index");
            }
            return View(productViewModel);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            var product = new UpdateProductViewModel()
            {
                Product = new Product()
            };
            return View(product);
        }


        [HttpPost]
        public async Task<IActionResult> AddProduct(UpdateProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                var product = productViewModel.Product;
                string folder = string.Empty;
                if (product.CoverPhoto != null)
                {
                    folder = (Guid.NewGuid() + product.CoverPhoto.FileName).ToString();
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images/" + folder);

                    await product.CoverPhoto.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }

                if (folder != string.Empty)
                {
                    product.Desciption = folder;
                }
                if (products.Count > 0)
                {
                    product.Id = products[products.Count - 1].Id + 1;
                }
                else
                {
                    product.Id = 1;
                }
                products.Add(product);
                return RedirectToAction("Index");
            }
            return View(productViewModel);
        }
    }
}
