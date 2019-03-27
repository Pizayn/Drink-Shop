using System;
using System.Collections.Generic;
using System.Text;
using DrinkShopCore.Entities;

namespace Drink.Entities.Concrete
{
    public class CartLine
    {
        public  Product Product { get; set; }
        public int Quantity { get; set; }
      
    }
}
