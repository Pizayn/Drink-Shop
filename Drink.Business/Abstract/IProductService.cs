using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrinkShopCore.Entities;

namespace DrinkShop.Business.Abstract
{
   public interface IProductService
   {
       void Add(Product product);
       void Delete(Product product);
       void Update(Product product);
       List<Product> GetAllProducts();
       List<Product> GetByCategoryId(int categoryId);
       List<Product> GetBySubCategoryId(int categoryId,int subCategoryId);

        Product GetByProductId(int productId);
        List<Product> GetBySearchProduct(string searchProduct);
   }
}
