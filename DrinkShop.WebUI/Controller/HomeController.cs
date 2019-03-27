using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Drink.Business.Abstract;
using DrinkShop.Business.Abstract;
using DrinkShop.WebUI.Entities;
using DrinkShop.WebUI.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DrinkShop.WebUI.Controller
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly UserManager<CustomIdentityUser> _userManager;
        private IProductService _productService;
        private ICategoryService _categoryService;
        private ISubCategoryService _subCategoryService;

        public HomeController(IProductService productService, UserManager<CustomIdentityUser> userManager, ICategoryService categoryService, ISubCategoryService subCategoryService)
        {
            _productService = productService;
            _userManager = userManager;
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
        }

        public IActionResult Index()
        {
          
            var product = _productService.GetAllProducts();
            ProductListViewModel model=new ProductListViewModel()
            {
              Products = product,
              Categories = _categoryService.GetAllCategories(),
              SubCategories = _subCategoryService.GetAll(),
              GetWines = _productService.GetByCategoryId(1),
              CurrentAction = HttpContext.Request.ContentType,
              GetBeers = _productService.GetByCategoryId(2),
              
            };
            return View(model);
        }
    }
}