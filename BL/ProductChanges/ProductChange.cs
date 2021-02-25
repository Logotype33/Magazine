using BL.ProductChanges.LoadImg;
using DataLayer.Models.DbModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ProductChanges
{
    public abstract class ProductChdange : IProductChange
    {
        public Product Product { get; set; }
        protected ProductInfo _productInfo;
        protected ILoad load;
        public ProductChdange(ProductInfo productInfo)
        {
            _productInfo = productInfo;
            Product = _productInfo.Product;

        }
        public virtual void Change()
        {
            load.Loading(_productInfo);
        }
        protected void Loading()
        {
            using (var fileStream = new FileStream(_productInfo.Root + _productInfo.Path, FileMode.OpenOrCreate))
            {
                _productInfo.UploadedFile.CopyTo(fileStream);
            }
        }
       
    }
}
