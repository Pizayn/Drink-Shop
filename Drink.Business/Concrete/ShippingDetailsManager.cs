using System;
using System.Collections.Generic;
using System.Text;
using Drink.Business.Abstract;
using Drink.DataAccess.Abstract;
using Drink.Entities.Concrete;

namespace Drink.Business.Concrete
{
  public  class ShippingDetailsManager:IShippingDetailsService
  {
      private IShippingDetailsDal _shippingDetailsDal;

      public ShippingDetailsManager(IShippingDetailsDal shippingDetailsDal)
      {
          _shippingDetailsDal = shippingDetailsDal;
      }

      public void Add(ShippingDetails shippingDetails)
        {
           _shippingDetailsDal.Add(shippingDetails);
        }

        public void Delete(ShippingDetails shippingDetails)
        {
           _shippingDetailsDal.Delete(shippingDetails);
        }

        public void Update(ShippingDetails shippingDetails)
        {
           _shippingDetailsDal.Update(shippingDetails);
        }
    }
}
