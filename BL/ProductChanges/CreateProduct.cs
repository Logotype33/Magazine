using BL.ProductChanges.LoadImg;
using DataLayer.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ProductChanges
{
    /// <summary>
    /// Класс создания продукта
    /// </summary>
    public class CreateProduct : ProductChdange
    {
        public CreateProduct(ProductInfo productInfo) : base(productInfo)
        {
            load = new Load();
        }
        public override void Change()
        {
            base.Change();
            //В продукт записываеся новый экземпляр продукта
            Product = new Product() { Name = Product.Name, Price = Product.Price, Path = _productInfo.Path };
        }
    }
}
