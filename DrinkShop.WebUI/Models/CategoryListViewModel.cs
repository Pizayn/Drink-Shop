using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Drink.Entities.Concrete;
using DrinkShopCore.Entities;

namespace DrinkShop.WebUI.Models
{
    public class CategoryListViewModel
    {
        public List<Category> Categories { get; set; }
        public int CurrentCategory { get; set; }
        public int CurrentSubCategory { get; set; }
        public List<SubCategory> SubCategories { get; set; }
        public string CurrentAction { get; set; }
        
    }
}
