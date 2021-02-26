using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ProductChanges.LoadImg
{
    /// <summary>
    /// Интерфейс загрузки
    /// </summary>
    public interface ILoad
    {
        /// <summary>
        /// Метод загрузки
        /// </summary>
        /// <param name="productInfo">Получает расширенный продукт</param>
        public void Loading(ProductInfo productInfo);
    }
}
