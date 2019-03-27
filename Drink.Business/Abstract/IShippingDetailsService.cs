using System;
using System.Collections.Generic;
using System.Text;
using Drink.Entities.Concrete;

namespace Drink.Business.Abstract
{
   public interface IShippingDetailsService
   {
       void Add(ShippingDetails shippingDetails);
       void Delete(ShippingDetails shippingDetails);
       void Update(ShippingDetails shippingDetails);


   }
}
