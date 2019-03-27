using System;
using System.Collections.Generic;
using System.Text;
using Drink.Business.Abstract;
using Drink.DataAccess.Abstract;
using Drink.Entities.Concrete;

namespace Drink.Business.Concrete
{
   public class OrderManager:IOrderService
   {
       private IOrderDal _orderDal;

       public OrderManager(IOrderDal orderDal)
       {
           _orderDal = orderDal;
          
       }

       public void Add(Order order)
        {
           _orderDal.Add(order);
        }

        public void Delete(Order order)
        {
           _orderDal.Delete(order);
        }

        public void Update(Order order)
        {
           _orderDal.Update(order);
        }

      

        public List<Order> GetOrder(string accountId)
        {

            return _orderDal.GetList(a => a.AccountId == accountId);
        }

        public List<Order> GetOrderById(int orderId)
        {
            return _orderDal.GetList(o => o.Id == orderId);
        }
   }
}
