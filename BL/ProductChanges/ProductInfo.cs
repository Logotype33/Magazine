using DataLayer.Models.DbModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ProductChanges
{
    public class ProductInfo
    {
        public Product Product { get; set; }
        public IFormFile UploadedFile { get; set; }
        public string Root { get; set; }
       
        public string Path { get; set; }
        public ProductInfo(Product product, IFormFile uploadedFile,string root)
        {
            Product = product;
            UploadedFile = uploadedFile;
            Root = root;
            Path= "/Files/" + UploadedFile.FileName;
        }
    }
}
