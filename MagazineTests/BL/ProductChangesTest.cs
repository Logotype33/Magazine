using BL.ProductChanges;
using DataLayer.Models.DbModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineTests.BL
{
    [TestClass]
    public class ProductChangesTest
    {
        /// <summary>
        /// Продукт, который будет изменяться
        /// </summary>
        static readonly Product product= new Product()
        {
                Id = Guid.NewGuid(),
                Name = "asd",
                Price = 200,
                Path = "img.jpg"
            };
        /// <summary>
        /// Мок загружаемой картинки
        /// </summary>
        static readonly Mock<IFormFile> uploadedFile = new Mock<IFormFile>();
        /// <summary>
        /// Мок для получения пути к папке wwwroot
        /// </summary>
        static readonly Mock<IWebHostEnvironment> root = new Mock<IWebHostEnvironment>();
        readonly IProductChange editChange= new EditProduct(new ProductInfo(product, uploadedFile.Object, root.Object.ContentRootPath));
        readonly IProductChange createChange = new CreateProduct(new ProductInfo(product, uploadedFile.Object, root.Object.ContentRootPath));

        [TestMethod]
        public void EditProduct_EqualWithTakedProduct_Test()
        {

            var expected = editChange.Product;
            Assert.AreEqual(product, expected);
        }
        [TestMethod]
        public void EditProduct_NotNull()
        {
            Assert.IsNotNull(editChange.Product);
        }
        [TestMethod]
        public void CreateProduct_NotNull()
        {
            Assert.IsNotNull(editChange.Product);
        }
        [TestMethod]
        public void CreateProduct_EqualWithTakedProduct_Test()
        {
            var expected = createChange.Product;
            Assert.AreEqual(product, expected);
        }
    }
}
