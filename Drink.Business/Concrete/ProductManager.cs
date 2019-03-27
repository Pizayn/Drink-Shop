using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrinkShop.Business.Abstract;
using DrinkShopCore.DataAccess.Abstract;
using DrinkShopCore.Entities;

namespace DrinkShop.Business.Concrete
{
  public  class ProductManager:IProductService
  {
      private IProductDal _productDal;

      public ProductManager(IProductDal productDal)
      {
          _productDal = productDal;
      }

      public void Add(Product product)
        {
           _productDal.Add(product);
        }

        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }

        public List<Product> GetAllProducts()
        {
            return _productDal.GetList();
        }

        public List<Product> GetByCategoryId(int categoryId)
        {
            return _productDal.GetList(p=>p.CategoryId==categoryId || categoryId == 0);
        }

        public List<Product> GetBySubCategoryId(int categoryId, int subCategoryId)
        {
            return _productDal.GetList(c=>(c.CategoryId==categoryId || categoryId == 0) && (c.SubCategoryId==subCategoryId || subCategoryId==0) );
        }

        public Product GetByProductId(int productId)
        {
            return _productDal.Get(p => p.Id == productId);
        }

        public List<Product> GetBySearchProduct(string searchProduct)
        {
            return _productDal.GetList(p => p.ProductName.ToLower().Contains(searchProduct));
        }
  }
}
