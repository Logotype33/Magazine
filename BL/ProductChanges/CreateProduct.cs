using BL.ProductChanges.LoadImg;
using DataLayer.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ProductChanges
{
    public class CreateProduct : ProductChdange
    {
        public CreateProduct(ProductInfo productInfo) : base(productInfo)
        {
            load = new Load();
        }
        public override void Change()
        {
            base.Change();
            Product = new Product() { Name = Product.Name, Price = Product.Price, Path = Product.Path };
        }
    }
}
