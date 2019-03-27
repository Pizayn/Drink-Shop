using System;
using System.Collections.Generic;
using System.Text;
using Drink.Entities.Concrete;

namespace Drink.Business.Abstract
{
   public interface IOrderService
   {
       void Add(Order order);
       void Delete(Order order);
       void Update(Order order);
       List<Order> GetOrder(string accountId);
       List<Order> GetOrderById(int orderId);

   }
}
