using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspTask2.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [DisplayName("Product Name")]
        [Required(ErrorMessage = "Product Name is required")]
        public string Name { get; set; }

        [DisplayName("Product Image")]
        [Required(ErrorMessage = "Product image is required")]
        public IFormFile CoverPhoto { get; set; }

        public string Desciption { get; set; }

        [Range(10, 100, ErrorMessage = "Range should be 1-400")]
        public double Price { get; set; }
        public double Discount { get; set; }
    }
}
