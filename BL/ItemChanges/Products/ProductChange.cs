using BL.ItemChanges.Load;
using DataLayer.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ItemChanges.Products
{
    public abstract class ProductChange:IChange<Product>
    {
        protected Product _product;
        protected ProductInfo _productInfo;
        protected ILoad _load;
        public ProductChange(ProductInfo productInfo)
        {
            _productInfo = productInfo;
            _product = productInfo.Item;
        }

        public abstract void Change();


        public Product GetT()
        {
            return _product;
        }
    }
}
