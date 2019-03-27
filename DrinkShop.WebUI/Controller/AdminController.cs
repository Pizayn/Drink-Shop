using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Drink.Business.Abstract;
using DrinkShop.Business.Abstract;
using DrinkShop.WebUI.Models;
using DrinkShop.WebUI.ValidationRules;
using DrinkShopCore.Entities;
using DrinkShopCore.Entities.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DrinkShop.WebUI.Controller
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Microsoft.AspNetCore.Mvc.Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        private readonly IHostingEnvironment _appEnvironment;
        private ISubCategoryService _subCategoryService;
       

        public AdminController(IProductService productService, ICategoryService categoryService, IHostingEnvironment appEnvironment, ISubCategoryService subCategoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _appEnvironment = appEnvironment;
            _subCategoryService = subCategoryService;
          
        }

        public IActionResult Index(int category = 0, int subCategory = 0, string searchProduct = "")
        {
            ProductListViewModel model=new ProductListViewModel()
            {
                Products = _productService.GetBySubCategoryId(category, subCategory),
            };

            if (searchProduct != "")
            {
                model.Products = _productService.GetBySearchProduct(searchProduct);



            }

           
            return View(model);
        }

        public IActionResult Update(int productId,int subCategoryId)
        {
          ProductUpdateViewModel model=new ProductUpdateViewModel()
          {
              Product = _productService.GetByProductId(productId),
              Categories = _categoryService.GetAllCategories(),
              SubCategories = _subCategoryService.GetAll(),

              
          };
          return View(model);
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(product);
                TempData.Add("message", "Product was succesfully updated");
            }

            return RedirectToAction("Index");



        }

        public IActionResult Delete(Product product)
        {
            string path_root = _appEnvironment.WebRootPath + "/Upload";
            string pathToImages = path_root + "\\" + product.Image;
            if (System.IO.File.Exists(pathToImages))
            {
                System.IO.File.Delete(pathToImages);
            }
            _productService.Delete(product);
            TempData.Add("message", "Product was succesfully deleted");
          
            return RedirectToAction("Index");

        }

        public IActionResult Add()
        {
            ProductAddViewModel model=new ProductAddViewModel()
            {
                Product = new Product(),
                Categories =_categoryService.GetAllCategories(),
                SubCategories = _subCategoryService.GetAll(),
                //ValidationResults = new List<string>(),
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Product product)
        {
           

            if (product.ImageUpload.Length == 0 && product.ImageUpload == null)
            {
                TempData.Add("message"," file not selected");
                return RedirectToAction("Add");
            }
            else
            {
                product.Image = product.ProductName + ".jpg";
                string path_root = _appEnvironment.WebRootPath + "/Upload";
                string path_to_Images = path_root + "\\" + product.Image;
                using (var stream = new FileStream(path_to_Images, FileMode.Create))

                {

                    await product.ImageUpload.CopyToAsync(stream);

                }
            }
           
            ProductValidator productValidator=new ProductValidator();
            ValidationResult result = productValidator.Validate(product);
            
            if (!result.IsValid)
            {
                ProductAddViewModel model=new ProductAddViewModel()
                {
                    Product = product,
                    Categories = _categoryService.GetAllCategories(),
                    SubCategories = _subCategoryService.GetAll(),
                    //ValidationResults = new List<string>()
                };

                foreach (var x in result.Errors)
                {

                    ModelState.AddModelError(x.PropertyName,x.ErrorMessage);
                }

                return View(model);



            }
            else
            {
                _productService.Add(product);
                TempData.Add("message", "Product was successfully added");
                return RedirectToAction("Add");
            }
            //if (ModelState.IsValid)
            //{
            //    
            //}






            
        }
        public JsonResult GetStateById(int ID)
        {
           
  
            return Json((_subCategoryService.GetByCategoryId(ID)));
        }

    }
}