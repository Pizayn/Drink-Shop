using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinkShop.Business.Abstract;
using DrinkShop.WebUI.Models;
using DrinkShopCore.Entities.Concrete;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DrinkShop.WebUI.Controller
{
    public class ProductController : Microsoft.AspNetCore.Mvc.Controller
    {
       DrinkShopContext context=new DrinkShopContext();
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index(int page=1,int category=0,int subCategory=0,string searchProduct="")
        {
            int pageSize = 3;
            var products = _productService.GetBySubCategoryId(category, subCategory);
            ProductListViewModel model = new ProductListViewModel()
            {
                Products = products.Skip((page-1)*pageSize).Take(pageSize).ToList(),
                CurrentAction = HttpContext.Request.Path,
                CurrentCategory = category,
                CurrentSubCategory = subCategory,
                CurrentPage = page,
                PageSize = pageSize,
                PageCount = (int)Math.Ceiling(products.Count/ (double)pageSize)
            };



            if (searchProduct!="")
            {
                model.Products = _productService.GetBySearchProduct(searchProduct);
                


            }

            return View(model);





        }

      

        public ActionResult Details(int productId)
        {
            var query = from p in context.Products
                join c in context.Categories on p.CategoryId equals c.Id
                join s in context.SubCategories on p.SubCategoryId equals s.Id
                where productId==p.Id
                select new ProductDetailsModel()
                {
                    ProductName = p.ProductName,
                    Id = p.Id,
                    Image = p.Image,
                    UnitPrice = p.UnitPrice,
                    CategoryName = c.CategoryName,
                    SubCategoryName = s.Name,
                    CategoryId = p.CategoryId,
                    SubCategoryId = p.SubCategoryId

                };
           ProductDetailsViewModel model=new ProductDetailsViewModel()
           {
              ProductDetailsModel = query.ToList()
           };
            return View(model);
        }

        public ActionResult SearchProduct(object searchProduct)
        {
           
            return RedirectToAction("Index",searchProduct);
        }
    }
}