using BL.ItemChanges.Load;
using DataLayer.Models.DbModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BL.ItemChanges.ItemInfo.INewItem;

namespace BL.ItemChanges.Products
{
    public class ProductInfo : INewItem<Product>, IUploadedFile
    {
        public Product Item { get; set; }
        public IFormFile UploadedFile { get; set; }

        public string Root { get; set; }

        public string Path { get; set; }
        public ProductInfo(Product product, IFormFile uploadedFile, string root)
        {
            Item = product;
            UploadedFile = uploadedFile;
            Root = root;
        }
    }
}
