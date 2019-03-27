using System;
using System.Collections.Generic;
using System.Text;
using DrinkShopCore.Entities;

namespace Drink.Business.Abstract
{
   public interface ICategoryService
   {
       void Add(Category category);
       void Delete(Category category);
       void Update(Category category);
       List<Category> GetAllCategories();
   }
}
