using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ProductChanges.LoadImg
{
    /// <summary>
    /// Класс реализующий загрузочный интерфейс
    /// </summary>
    public class Load : ILoad
    {
        
        public void Loading(ProductInfo productInfo)
        {
            using (var fileStream = new FileStream(productInfo.Root + productInfo.Path, FileMode.OpenOrCreate))
            {
                productInfo.UploadedFile.CopyTo(fileStream);
            }
        }
        

        
    }
}
