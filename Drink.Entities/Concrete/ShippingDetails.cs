using System;
using System.Collections.Generic;
using System.Text;
using DrinkShopCore.Entities.Abstract;

namespace Drink.Entities.Concrete
{
  public  class ShippingDetails:IEntity
    {
        public string Province { get; set; }
        public string District { get; set; }
        public string Neighborhood { get; set; }
        public string Name { get; set; }
        public string AccountId { get; set; }
    }
}
