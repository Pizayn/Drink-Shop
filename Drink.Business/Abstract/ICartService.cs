using System;
using System.Collections.Generic;
using System.Text;
using Drink.Entities.Concrete;
using DrinkShopCore.Entities;

namespace Drink.Business.Abstract
{
   public interface ICartService
   {
       void AddToCart(Cart cart, Product product);
       void RemoveCart(Cart cart, int productId);
       List<CartLine>List(Cart cart);
   }
}
