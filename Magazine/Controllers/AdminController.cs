using BL;
using BL.ProductChanges;
using DataLayer;
using DataLayer.Models;
using DataLayer.Models.DbModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace Magazine.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController:Controller
    {
        private readonly UnitOfWork _unit;
        private readonly IWebHostEnvironment _appEnvironment;
        private IProductChange change;
        public AdminController(UnitOfWork unit, IWebHostEnvironment appEnvironment)
        {
            _unit = unit;
            _appEnvironment = appEnvironment;
        }
        public IActionResult Index()
        {
            return View(_unit.Product.Get());
        }
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product, IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                change = new CreateProduct(new ProductInfo(product, uploadedFile, _appEnvironment.WebRootPath));
                change.Change();
                _unit.Product.Create(change.Product);
            }
            else
            {
                _unit.Product.Create(product);
            }
            _unit.Save();
           

            return RedirectToAction("Index");
        }
        public IActionResult EditProduct(Guid productID)
        {
            if (productID != null)
            {
                Product product = _unit.Product.FindById(productID);
                return View(product);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult EditProduct(Product product, IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                change = new EditProduct(new ProductInfo(product, uploadedFile, _appEnvironment.WebRootPath));
                change.Change();


                _unit.Product.Update(change.Product);
            }
            else
            {
                _unit.Product.Update(product);
            }
            _unit.Save();
            
            return RedirectToAction("Index");
        }
        public IActionResult Orders()
        {
            
            return View(_unit.Order.OrderThenInclude());

        }
        public IActionResult Details(Guid OrderId)
        {
            return View(_unit.Order.OrderThenInclude().Where(x => x.ID == OrderId));
        }
        [HttpPost]
        public IActionResult CancelOrder(Guid OrderId)
        {
            var order = _unit.Order.FindById(OrderId);

            order.OrderStatus = Status.StatusList.Отменён.ToString();
            _unit.Order.Update(order);
            _unit.Save();
            return RedirectToAction("Orders", "Admin");
        }
        [HttpPost]
        public IActionResult ConfirmOrder(Guid OrderId)
        {
            var order = _unit.Order.FindById(OrderId);

            order.OrderStatus = Status.StatusList.Выполнен.ToString();
            _unit.Order.Update(order);
            _unit.Save();
            return RedirectToAction("Orders", "Admin");

        }
        [HttpPost]
        public  IActionResult DeleteProduct(Guid productID)
        {
            Product product = _unit.Product.FindById(productID);
            if (product != null)
            {
                _unit.Product.Remove(product);
                _unit.Save();
                return RedirectToAction("Index");

            }
            return NotFound();
        }
    }
}
