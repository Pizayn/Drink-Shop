using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Drink.Entities.Concrete;
using DrinkShopCore.Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;

namespace DrinkShop.WebUI.Models
{
    public class ProductAddViewModel
    {
    
        public List<Category> Categories { get; set; }
        public Product Product { get; set; }
        public List<SubCategory> SubCategories { get; set; }
        public List<string> ValidationResults { get; set; }
        
    }
}
