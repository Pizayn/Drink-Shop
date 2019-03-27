using System;
using System.Collections.Generic;
using System.Text;
using Drink.Business.Abstract;
using Drink.DataAccess.Abstract;
using Drink.Entities.Concrete;

namespace Drink.Business.Concrete
{
   public class SubCategoryService:ISubCategoryService
   {
       private ISubCategoryDal _subCategoryDal;

       public SubCategoryService(ISubCategoryDal subCategoryDal)
       {
           _subCategoryDal = subCategoryDal;
       }

       public List<SubCategory> GetAll()
       {
           return _subCategoryDal.GetList();
       
        
       }

       public List<SubCategory> GetBySubCategoryId(int subCategoryId)
       {
           return _subCategoryDal.GetList(p => p.Id == subCategoryId);
       }

       public List<SubCategory> GetByCategoryId(int id)
       {
           return _subCategoryDal.GetList(c => c.CategoryId == id);
       }
   }
}
