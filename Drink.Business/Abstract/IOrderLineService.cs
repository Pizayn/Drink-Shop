using System;
using System.Collections.Generic;
using System.Text;
using Drink.Entities.Concrete;

namespace Drink.Business.Abstract
{
   public interface IOrderLineService
   {
       void Add(OrderLine orderLine);
       void Delete(OrderLine orderLine);
       void Update(OrderLine orderLine);
       List<OrderLine> GetAll();
       List<OrderLine> GetByAccountId(string accountId);
   }
}
