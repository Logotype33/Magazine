using DataLayer.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ItemChanges.Orders
{
    public abstract class OrderChange : IChange<Order>
    {
        protected OrderInfo _opderInfo;
        protected Order _order;
        public OrderChange(OrderInfo orderInfo)
        {
            _opderInfo = orderInfo;
           
        }
        public abstract void Change();

        public Order GetT()
        {
            return _order;
        }
    }
}
