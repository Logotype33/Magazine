using BL.ItemChanges;
using BL.ItemChanges.Products;
using BL.UnitOfWorkFolder;
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
        private readonly IUnitOfWork _unit;
        

        private readonly IWebHostEnvironment _appEnvironment;
        private IChange<Product> change;
        public AdminController(IUnitOfWork unit, IWebHostEnvironment appEnvironment)
        {
            _unit = unit;
           
            _appEnvironment = appEnvironment;
        }
        public IActionResult Index()
        {
            return View(_unit.GetRepo<Product>().Get());
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
                _unit.GetRepo<Product>().Create(change.GetT());
            }
            else
            {
                _unit.GetRepo<Product>().Create(product);
            }
            _unit.SaveChanges();
           

            return RedirectToAction("Index");
        }
        public IActionResult EditProduct(Guid productID)
        {
            if (productID != null)
            {
                Product product = _unit.GetRepo<Product>().FindById(productID);
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

                
                _unit.GetRepo<Product>().Update(change.GetT());
            }
            else
            {
                _unit.GetRepo<Product>().Update(product);
            }
            _unit.SaveChanges();
            
            return RedirectToAction("Index");
        }
        public IActionResult Orders()
        {
            
            return View(_unit.GetRepo<Order>().OrderThenInclude());

        }
        public IActionResult Details(Guid OrderId)
        {
            return View(_unit.GetRepo<Order>().OrderThenInclude().Where(x => x.ID == OrderId));
        }
        [HttpPost]
        public IActionResult CancelOrder(Guid OrderId)
        {
            var order = _unit.GetRepo<Order>().FindById(OrderId);

            order.OrderStatus = Status.StatusList.Отменён.ToString();
            _unit.GetRepo<Order>().Update(order);
            _unit.SaveChanges();
            return RedirectToAction("Orders", "Admin");
        }
        [HttpPost]
        public IActionResult ConfirmOrder(Guid OrderId)
        {
            var order = _unit.GetRepo<Order>().FindById(OrderId);

            order.OrderStatus = Status.StatusList.Выполнен.ToString();
            _unit.GetRepo<Order>().Update(order);
            _unit.SaveChanges();
            return RedirectToAction("Orders", "Admin");

        }
        [HttpPost]
        public  IActionResult DeleteProduct(Guid productID)
        {
            Product product = _unit.GetRepo<Product>().FindById(productID);
            if (product != null)
            {
                _unit.GetRepo<Product>().Remove(product);
                _unit.SaveChanges();
                return RedirectToAction("Index");

            }
            return NotFound();
        }
    }
}
