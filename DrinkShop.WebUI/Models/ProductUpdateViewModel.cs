using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Drink.Entities.Concrete;
using DrinkShopCore.Entities;

namespace DrinkShop.WebUI.Models
{
    public class ProductUpdateViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
        public List<SubCategory> SubCategories { get; set; }
    }
}
