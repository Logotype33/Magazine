using BL.ItemChanges.Load;
using DataLayer.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ItemChanges.Products
{
    public class CreateProduct:ProductChange
    {
        public CreateProduct(ProductInfo productInfo) : base(productInfo)
        {
            _load = new LoadProductImage();
        }
        public CreateProduct(ProductInfo productInfo, ILoad load) : base(productInfo)
        {
            _load = load;
        }

        public override void Change()
        {
            _load.Loading(_productInfo);
            _product = new Product() { Id = _product.Id, Name = _product.Name, Price = _product.Price, Path = _productInfo.Path };
        }
    }
}
