using BL.Repo;
using DataLayer.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UnitOfWork
    {
        private EFGenericRepository<Product> _productRepo;
        private EFGenericRepository<Order> _orderRepo;
        private readonly MagazineContext _context;
        public UnitOfWork(MagazineContext context)
        {
            _context = context;
        }
        public EFGenericRepository<Product> Product
        {
            get
            {
                if (_productRepo == null)
                {
                    _productRepo = new EFGenericRepository<Product>(_context);
                }
                return _productRepo;
            }
        }
        public EFGenericRepository<Order> Order
        {
            get
            {
                if (_orderRepo == null)
                {
                    _orderRepo = new EFGenericRepository<Order>(_context);
                }
                return _orderRepo;
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
