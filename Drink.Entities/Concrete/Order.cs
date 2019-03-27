using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using DrinkShopCore.Entities;
using DrinkShopCore.Entities.Abstract;

namespace Drink.Entities.Concrete
{
   public class Order:IEntity
    {
        public int Id { get; set; }
        [Required]
        public int Total { get; set; }
        [Required]
        public string AccountId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Sehir { get; set; }
        [Required]
        public string Semt { get; set; }
        [Required]
        public string Mahalle { get; set; }
      
    }
   public class OrderLine:IEntity
   {

        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string AccountId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int OrderId { get; set; }
   }
}
