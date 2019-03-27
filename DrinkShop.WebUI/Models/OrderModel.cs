using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Drink.Entities.Concrete;

namespace DrinkShop.WebUI.Models
{
    public class OrderModel
    {
        public List<Order> Orders { get; set; }
    }
}
