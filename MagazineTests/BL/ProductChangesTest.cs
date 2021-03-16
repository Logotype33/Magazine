using BL.ItemChanges;
using BL.ItemChanges.Load;
using BL.ItemChanges.Products;
using DataLayer.Models.DbModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
       
        /// <summary>
        /// Мок загружаемой картинки
        /// </summary>
        static readonly Mock<IFormFile> uploadedFile = new Mock<IFormFile>();
        /// <summary>
        /// Мок для получения пути к папке wwwroot
        /// </summary>
        static readonly Mock<IWebHostEnvironment> root = new Mock<IWebHostEnvironment>();

        static readonly Mock<ILoad> load = new Mock<ILoad>();
        static readonly Product product = new Product()
        {
            Id = Guid.NewGuid(),
            Name = "asd",
            Price = 200,
            Path = uploadedFile.Object.FileName
        };
        readonly IChange<Product> editChange = new EditProduct(new ProductInfo(product, uploadedFile.Object, root.Object.ContentRootPath),load.Object);
        readonly IChange<Product> createChange = new CreateProduct(new ProductInfo(product, uploadedFile.Object, root.Object.ContentRootPath),load.Object);


        [TestMethod]
        public void EditProduct_EqualWithTakedProduct_Test()
        {
            editChange.Change();
            var expected = editChange.GetT();
            Assert.AreEqual(product, expected);
        }
        [TestMethod]
        public void EditProduct_NotNull()
        {
            editChange.Change();
            Assert.IsNotNull(editChange.GetT()); ;
        }
        [TestMethod]
        public void CreateProduct_NotNull()
        {
            createChange.Change();
            Assert.IsNotNull(editChange.GetT());
        }
        [TestMethod]
        public void CreateProduct_EqualWithTakedProduct_Test()
        {
            createChange.Change();
            var expected1 = createChange.GetT();
            //Сравниваются по значению каждого свойства т.к. из-за создания нового продукта в createChange.Change()
            //насколько я понял получились разные екзепляры с одинаковыми значениями и тест не проходил.
            Assert.AreEqual(expected1.Id, product.Id);
            Assert.AreEqual(expected1.Name, product.Name);
            Assert.AreEqual(expected1.Price, product.Price);
            Assert.AreEqual(expected1.Path, product.Path);

            #region Вывод сравнений в сообщение
            //var expected2 = new Product() 
            //{
            //    Id = product.Id,
            //    Name = product.Name,
            //    Path = product.Path,
            //    Price = product.Price 
            //};
            //Debug.WriteLine(expected2.Id.ToString());
            //Debug.WriteLine(expected2.Name);
            //Debug.WriteLine(expected2.Price);
            //Debug.WriteLine(expected2.Path);
            //Debug.WriteLine("");
            //Debug.WriteLine(expected1.Id.ToString());
            //Debug.WriteLine(expected1.Name);
            //Debug.WriteLine(expected1.Price);
            //Debug.WriteLine(expected1.Path);
            //Debug.WriteLine("");
            //Debug.WriteLine(expected1.ToString());
            //Debug.WriteLine(expected2);
            //Debug.WriteLine(product);
            //Assert.AreEqual(expected1, product);
            //Assert.AreEqual(expected1,expected2);
            #endregion



        }
    }
}
