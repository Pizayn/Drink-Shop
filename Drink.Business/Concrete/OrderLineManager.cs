using System;
using System.Collections.Generic;
using System.Text;
using Drink.Business.Abstract;
using Drink.DataAccess.Abstract;
using Drink.Entities.Concrete;

namespace Drink.Business.Concrete
{
  public  class OrderLineManager:IOrderLineService
  {
      private IOrderLineDal _orderLineDal;

      public OrderLineManager(IOrderLineDal orderLineDal)
      {
          _orderLineDal = orderLineDal;
      }

      public void Add(OrderLine orderLine)
        {
           
            _orderLineDal.Add(orderLine);
        }

        public void Delete(OrderLine orderLine)
        {
            _orderLineDal.Delete(orderLine);
        }

        public void Update(OrderLine orderLine)
        {
            _orderLineDal.Update(orderLine);
        }

        public List<OrderLine> GetAll()
        {
            return _orderLineDal.GetList();
        }

        public List<OrderLine> GetByAccountId(string accountId)
        {
            return _orderLineDal.GetList(a => a.AccountId == accountId);
            
        }
  }
}
