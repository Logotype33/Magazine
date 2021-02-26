using DataLayer.Models.DbModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ProductChanges
{
    /// <summary>
    /// Расширенный продукт
    /// </summary>
    //
    public class ProductInfo
    {
        /// <summary>
        /// Получаемый продукт
        /// </summary>
        public Product Product { get; set; }
        /// <summary>
        /// Загружаемый файл
        /// </summary>
        public IFormFile UploadedFile { get; set; }
        /// <summary>
        /// Путь до wwwroot
        /// </summary>
        public string Root { get; set; }
        /// <summary>
        /// Путь после wwwroot с названием изображения
        /// </summary>
        public string Path { get; set; }
        public ProductInfo(Product product, IFormFile uploadedFile,string root)
        {
            Product = product;
            UploadedFile = uploadedFile;
            Root = root;
            // Files/ папка внутри wwwroot
            Path= "/Files/" + UploadedFile.FileName;
        }
    }
}
