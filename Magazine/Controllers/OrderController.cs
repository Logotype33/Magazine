using BL;
using BL.ItemChanges;
using BL.ItemChanges.Orders;
using BL.UnitOfWorkFolder;
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
        private readonly IUnitOfWork _unit;
        private IChange<Order> change;
        public OrderController(UserManager<IdentityUser> userManager, SessionCart cart, IUnitOfWork unit)
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
                    var info = new OrderInfo(
                        Guid.Parse(_userManager.GetUserId(User)),
                        _unit.GetRepo<Order>().Get().Count() + 1,
                        _cart);
                    change = new CreateOrder(info);
                    change.Change();
                    _unit.GetRepo<Order>().Create(change.GetT());
                    _unit.SaveChanges();
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
                return View(_unit.GetRepo<Order>().OrderThenInclude().Where(x=>x.UserId == Guid.Parse(_userManager.GetUserId(User))));
            }
            else
            {
                return NotFound();
            }
        }
        public IActionResult Details(Guid OrderId)
        {
            return View(_unit.GetRepo<Order>().OrderThenInclude().Where(x=>x.ID==OrderId));
        }
    }
}
