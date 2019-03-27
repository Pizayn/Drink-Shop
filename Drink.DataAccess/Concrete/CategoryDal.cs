using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrinkShopCore.DataAccess.Abstract;
using DrinkShopCore.Entities;
using DrinkShopCore.Entities.Concrete;

namespace DrinkShopCore.DataAccess.Concrete
{
    public class CategoryDal:RepositoryDal<Category,DrinkShopContext>,ICategoryDal
    {

    }
}
