using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinkShopCore.Entities;

namespace DrinkShop.WebUI.Models
{
    public class ProductDetailsModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public int UnitPrice { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
    }

    public class ProductDetailsViewModel
    {
        public List<ProductDetailsModel> ProductDetailsModel { get; set; }
    }
}
