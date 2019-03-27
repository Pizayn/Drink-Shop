using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Drink.Entities.Concrete;
using DrinkShopCore.Entities;

namespace DrinkShop.WebUI.Models
{
    public class ProductListViewModel
    {
        public List<Product>Products  { get; set; }
        public List<Category> Categories { get; set; }
        public List<SubCategory> SubCategories { get; set; }
        public List<Product> GetWines { get; set; }
        public List<Product> GetBeers { get; set; }
        public string CurrentAction { get; set; }
        public int CurrentCategory { get; set; }
        public int CurrentSubCategory { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        
       
        
    }
}
