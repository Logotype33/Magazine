using DataLayer.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ProductChanges
{
    public interface IProductChange
    {
        public Product Product { get; set; }
        public void Change();
    }
}
