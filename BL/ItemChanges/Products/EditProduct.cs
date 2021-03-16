using BL.ItemChanges.Load;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ItemChanges.Products
{
    public class EditProduct : ProductChange
    {
        public EditProduct(ProductInfo productInfo):base(productInfo)
        {
            _load = new LoadProductImage();
        }
        public EditProduct(ProductInfo productInfo,ILoad load) : base(productInfo)
        {
            _load = load;
        }
        public override void Change()
        {
            _load.Loading(_productInfo);
            _product.Path = _productInfo.Path;
        }
    }
}
