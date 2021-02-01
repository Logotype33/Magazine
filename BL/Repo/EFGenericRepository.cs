
using DataLayer.Models.DbModels;
using DataLayer.Repo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL.Repo
{
    public class EFGenericRepository<TEntity> : IRepo<TEntity> where TEntity : class
    {
        private readonly MagazineContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public EFGenericRepository(MagazineContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public IEnumerable<TEntity> Get()
        {
            return _dbSet.ToList();
        }

        
        public TEntity FindById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public void Create(TEntity item)
        {
            _dbSet.Add(item);
        }
        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
        }


        public IEnumerable<Order> OrderThenInclude()
        {
            return _context.Orders.Include(x => x.Products).ThenInclude(op => op.Product);
        }

    }
}
