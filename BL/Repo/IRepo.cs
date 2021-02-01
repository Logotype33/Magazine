using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repo
{
    public interface IRepo<TEntity> where TEntity : class
    {
        void Create(TEntity item);
        TEntity FindById(Guid id);
        IEnumerable<TEntity> Get();
        void Remove(TEntity item);
        void Update(TEntity item);
    }
}
