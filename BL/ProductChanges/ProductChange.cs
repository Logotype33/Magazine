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

    /// <summary>
    /// Абстрактный класс изменения продукта
    /// </summary>
    //Класс абстрактный т.к. ILoad не имеет реализации в этом классе, сделано это простоты расширяемости метода Change()
    public abstract class ProductChdange : IProductChange
    {
        /// <summary>
        /// Изменённый продукт
        /// </summary>
        public Product Product { get; set; }
        /// <summary>
        /// Экземпляр полученного расширенного продукта
        /// </summary>
        protected ProductInfo _productInfo;
        /// <summary>
        /// Интерфейс загрузки, значение присваивается в конструкторе наследника
        /// </summary>
        protected ILoad load;
        /// <summary>
        /// Конструтор, в Product присваивается значение продукта из расширенного продукта
        /// </summary>
        /// <param name="productInfo">Получаемый расширенный продукт</param>
        public ProductChdange(ProductInfo productInfo)
        {
            _productInfo = productInfo;
            
            Product = _productInfo.Product;

        }
        /// <summary>
        /// Метод изменений, реализация загрузки зависит от значения интерфейса в наследнике класса
        /// </summary>
        public virtual void Change()
        {
            load.Loading(_productInfo);
        }
        
       
    }
}
