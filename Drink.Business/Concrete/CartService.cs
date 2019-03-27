using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Drink.Business.Abstract;
using Drink.Entities.Concrete;
using DrinkShopCore.Entities;

namespace Drink.Business.Concrete
{
    public class CartService:ICartService
    {
        public void AddToCart(Cart cart, Product product)
        {
            CartLine cartLine = cart.CartLines.FirstOrDefault(p => p.Product.Id == product.Id);
            if (cartLine!=null)
            {
                cartLine.Quantity++;
                return;
                
            }
            cart.CartLines.Add(new CartLine{Product = product,Quantity = 1});
        }

        public void RemoveCart(Cart cart, int productId)
        {
            cart.CartLines.Remove(cart.CartLines.FirstOrDefault(p => p.Product.Id == productId));
           
        }

        public List<CartLine> List(Cart cart)
        {
            return cart.CartLines;
        }
    }
}
