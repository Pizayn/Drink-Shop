using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drink.Entities.Concrete
{
    public class Cart
    {
        public Cart()
        {
            CartLines = new List<CartLine>();
            //içinde hiç bir ürün yokkken objct null hatası alırız.Buyüzden içine cartline nesnesini koyduk
        }
        public List<CartLine> CartLines { get; set; }

        public int Total
        {
            get { return CartLines.Sum(c => c.Product.UnitPrice * c.Quantity); }
        }
    }
}
