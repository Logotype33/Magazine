using BL;
using DataLayer;
using DataLayer.Models;
using DataLayer.Models.DbModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.Controllers
{
    public class CartController:Controller
    {
        
        private readonly SessionCart _cart;
        private readonly UnitOfWork _unit;
        private readonly UserManager<IdentityUser> _userManager;
        public CartController(UnitOfWork unit, SessionCart cart, UserManager<IdentityUser> userManager)
        {
            _cart = cart;
            _unit = unit;
            _userManager = userManager;
        }
        
        public IActionResult Index()
        {
            ViewBag.Total = _cart.ComputeTotalValue();
           
            return View(_cart.Lines.ToList());
        }
        //[HttpPost]
        //public void AddToCart(Guid? productID) => _cart.AddItem(_unit.Product.GetById(productID), 1);
        [HttpPost]
        public IActionResult AddToCart(Guid productID)
        {
            _cart.AddItem(_unit.Product.FindById(productID), 1);
            return RedirectToAction("Index","Cart");
        }

        public IActionResult IncreaseQ(Guid productID)
        {
            _cart.Increase(_unit.Product.FindById(productID));
            return RedirectToAction("Index");
        }
        public IActionResult DecreaseQ(Guid productID)
        {
            _cart.Decrease(_unit.Product.FindById(productID));
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult RemoveFromCart(Guid productID)
        {
            
            _cart.RemoveLine(_unit.Product.FindById(productID));
            return RedirectToAction("Index");
        }
        
        
        
     }
}
