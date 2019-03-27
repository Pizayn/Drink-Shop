using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrinkShopCore.Entities.Abstract;

namespace DrinkShopCore.Entities
{
    public class Category:IEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
       
    }
}
