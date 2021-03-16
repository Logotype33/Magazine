using DataLayer.Models;
using DataLayer.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ItemChanges.Orders
{
    public class CreateOrder : OrderChange
    {
        private List<OrderProduct> _orderProducts=new List<OrderProduct>();
        public CreateOrder(OrderInfo orderInfo) : base(orderInfo)
        {
            _opderInfo.Item = _order;
        }
        public override void Change()
        {
            //TODO: разделить функционал на части
            Order order = new Order()
            {

                UserId = _opderInfo.UserId,
                OrderNumber = _opderInfo.OrdNumb,
                OrderDate = DateTime.UtcNow,
                OrderStatus = Status.StatusList.Выполняется.ToString(),
                TotalPrice = _opderInfo.Cart.ComputeTotalValue(),
                Products = _orderProducts
            };

            foreach (var line in _opderInfo.Cart.Lines)
            {
                _orderProducts.Add(new OrderProduct()
                {
                    ID = Guid.NewGuid(),

                    ProductID = line.Product.Id,
                    ProductQuantity = line.Quantity
                });
            }
            _order = order;
            _order.Products = _orderProducts;
        }
    }
}
