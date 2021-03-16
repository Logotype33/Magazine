using DataLayer.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BL.ItemChanges.ItemInfo.INewItem;

namespace BL.ItemChanges.Orders
{
    public class OrderInfo : INewItem<Order>
    {
        public Order Item { get; set; }
        public Guid UserId { get; set; }
        public int OrdNumb { get; set; }
        public SessionCart Cart { get; set; }


        public OrderInfo(Guid userId, int ordNumb, SessionCart cart)
        {
            UserId = userId;
            OrdNumb = ordNumb;
            Cart = cart;
        }
    }
}
