﻿using BL;
using BL.UnitOfWorkFolder;
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
        private readonly IUnitOfWork _unit;
        private readonly UserManager<IdentityUser> _userManager;
        public CartController(IUnitOfWork unit, SessionCart cart, UserManager<IdentityUser> userManager)
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
        
        [HttpPost]
        public IActionResult AddToCart(Guid productID)
        {
            _cart.AddItem(_unit.GetRepo<Product>().FindById(productID), 1);
            return RedirectToAction("Index","Cart");
        }

        public IActionResult IncreaseQ(Guid productID)
        {
            _cart.Increase(_unit.GetRepo<Product>().FindById(productID));
            return RedirectToAction("Index");
        }
        public IActionResult DecreaseQ(Guid productID)
        {
            _cart.Decrease(_unit.GetRepo<Product>().FindById(productID));
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult RemoveFromCart(Guid productID)
        {
            
            _cart.RemoveLine(_unit.GetRepo<Product>().FindById(productID));
            return RedirectToAction("Index");
        }
        
        
        
     }
}
