using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ItemChanges
{
    public interface IChange<T> where T : class
    {
        T GetT();
        void Change();
    }
}
