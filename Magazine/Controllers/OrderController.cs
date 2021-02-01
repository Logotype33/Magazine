using BL;
using DataLayer;
using DataLayer.Models;
using DataLayer.Models.DbModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PresentLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.Controllers
{
    
    public class OrderController:Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SessionCart _cart;
        private readonly UnitOfWork _unit;
        public OrderController(UserManager<IdentityUser> userManager, SessionCart cart, UnitOfWork unit)
        {
            _cart = cart;
            _userManager = userManager;
           _unit=unit;
        }
        
        [HttpPost]
        public IActionResult CreateOrder()
        {
            if (User.Identity.IsAuthenticated)
            {



                if (!(_cart.Lines.Count() == 0))
                {
                    Order order = new Order()

                    {

                        UserId = Guid.Parse(_userManager.GetUserId(User)),
                        OrderNumber = _unit.Order.Get().Count() + 1,
                        OrderDate = DateTime.UtcNow,
                        OrderStatus = Status.StatusList.Выполняется.ToString(),
                        TotalPrice = _cart.ComputeTotalValue(),
                        Products = new List<OrderProduct>()
                    };

                    foreach (var line in _cart.Lines)
                    {
                        order.Products.Add(new OrderProduct()
                        {
                            ID = Guid.NewGuid(),

                            ProductID = line.Product.Id,
                            ProductQuantity = line.Quantity
                        });
                    }
                    _unit.Order.Create(order);
                    _unit.Save();
                    _cart.Clear();




                }


                return RedirectToAction("Index", "Shop");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public IActionResult OrderById()
        {
            if (User != null)
            {
                return View(_unit.Order.OrderThenInclude().Where(x=>x.UserId == Guid.Parse(_userManager.GetUserId(User))));
            }
            else
            {
                return NotFound();
            }
        }
        public IActionResult Details(Guid OrderId)
        {
            return View(_unit.Order.OrderThenInclude().Where(x=>x.ID==OrderId));
        }
    }
}
