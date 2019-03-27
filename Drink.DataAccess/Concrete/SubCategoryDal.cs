using System;
using System.Collections.Generic;
using System.Text;
using Drink.DataAccess.Abstract;
using Drink.Entities.Concrete;
using DrinkShopCore.DataAccess.Concrete;
using DrinkShopCore.Entities.Concrete;

namespace Drink.DataAccess.Concrete
{
    public class SubCategoryDal:RepositoryDal<SubCategory,DrinkShopContext>,ISubCategoryDal
    {
    }
}
