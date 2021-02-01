using BL;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magazine.Controllers
{
    public class ShopController : Controller
    {
        private readonly UnitOfWork _unit;
        public ShopController(UnitOfWork unit)
        {
            _unit = unit;
            
        }
        public IActionResult Index()
        {
            ViewBag.IsClicked = false;
            return View(_unit.Product.Get()) ;
        }
    }
}
