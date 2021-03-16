using BL.Repo;
using DataLayer.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.UnitOfWorkFolder
{
    #region//Updates.UnitOfWork
    //Ннаписал интерфейс и изменил реализацию, он стал более гибким, при добавлении новой сущности не нужно лезть в вкласс и писать новый пропс,
    //TODO: но теперь его можно не правильно использовать
    #endregion
    public class UnitOfWork:IUnitOfWork
    {
        private readonly MagazineContext _context;

        public UnitOfWork(MagazineContext context)
        {
            _context = context;
        }
        public EFGenericRepository<T> GetRepo<T>() where T : class
        {
            var eFGeneric = new EFGenericRepository<T>(_context);
            return eFGeneric;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
