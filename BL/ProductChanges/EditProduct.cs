using BL.ProductChanges.LoadImg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ProductChanges
{
    public class EditProduct:ProductChdange
    {
        public EditProduct(ProductInfo productInfo):base(productInfo)
        {
            load = new Load();
        }
        public override void Change()
        {
            base.Change();
            Product.Path = _productInfo.Path;
        }

        
    }
}
