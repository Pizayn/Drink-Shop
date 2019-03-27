using System;
using System.Collections.Generic;
using System.Text;
using Drink.Business.Abstract;
using DrinkShopCore.DataAccess.Abstract;
using DrinkShopCore.Entities;

namespace Drink.Business.Concrete
{
    public class CategoryManager:ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Add(Category category)
        {
           _categoryDal.Add(category);
        }

        public void Delete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void Update(Category category)
        {
           _categoryDal.Update(category);
        }

        public List<Category> GetAllCategories()
        {

            return _categoryDal.GetList();
        }
    }
}
