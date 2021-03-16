using BL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.UnitOfWorkFolder
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        EFGenericRepository<T> GetRepo<T>() where T : class;
    }
}
