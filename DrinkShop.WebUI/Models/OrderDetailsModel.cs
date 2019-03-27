using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Drink.Entities.Concrete;
using DrinkShopCore.Entities;

namespace DrinkShop.WebUI.Models
{
    public class OrderDetailsModel
    {
        public string Image { get; set; }
        public int Price { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int Id { get; set; }
        public int Total { get; set; }
        public string AccountId { get; set; }
        public string Name { get; set; }
        public string Sehir { get; set; }
        public string Semt { get; set; }
        public string Mahalle { get; set; }
        public int ProductId { get; set; }



    }

    public class OrderDetailsListViewModel
    {
        public List<OrderDetailsModel> OrderDetailsModels { get; set; }
        public List<Order> Orders { get; set; }
    }
}
