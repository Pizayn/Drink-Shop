using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Drink.Entities.Concrete;

namespace DrinkShop.WebUI.Services
{
  public  interface ICartSessionService
  {
      Cart GetCart();
      void SetCart(Cart cart);
  }
}
