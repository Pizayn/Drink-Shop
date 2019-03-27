using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Drink.Business.Abstract;
using DrinkShop.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace DrinkShop.WebUI.ViewComponents
{
    public class NavbarViewComponentModel:ViewComponent
    {
        private ICategoryService _categoryService;
        private ISubCategoryService _subCategoryService;

        public NavbarViewComponentModel(ICategoryService categoryService, ISubCategoryService subCategoryService)
        {
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
        }

        public ViewViewComponentResult Invoke()
        {
            CategoryListViewModel model=new CategoryListViewModel()
            {
                Categories = _categoryService.GetAllCategories(),
                SubCategories = _subCategoryService.GetAll(),
            };
            return View(model);

        }
    }
}
