using BL;
using BL.UnitOfWorkFolder;
using DataLayer;
using DataLayer.Models.DbModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magazine.Controllers
{
    public class ShopController : Controller
    {
        private readonly IUnitOfWork _unit;
        public ShopController(IUnitOfWork unit)
        {
            _unit = unit;
            
        }
        public IActionResult Index()
        {
            return View(_unit.GetRepo<Product>().Get()) ;
        }
    }
}
