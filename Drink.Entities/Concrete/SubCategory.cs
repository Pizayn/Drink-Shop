using System;
using System.Collections.Generic;
using System.Text;
using DrinkShopCore.Entities.Abstract;

namespace Drink.Entities.Concrete
{
    public class SubCategory:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
}
