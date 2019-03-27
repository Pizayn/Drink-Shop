using System;
using System.Collections.Generic;
using System.Text;
using Drink.Entities.Concrete;

namespace Drink.Business.Abstract
{
   public interface ISubCategoryService
   {
       List<SubCategory> GetAll();
       List<SubCategory> GetBySubCategoryId(int subCategoryId);
       List<SubCategory> GetByCategoryId(int id);
   }
}
