using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ItemChanges.ItemInfo
{
    public interface INewItem
    {
        public interface INewItem<T> where T : class
        {
            public T Item { get; set; }
        }
    }
}
