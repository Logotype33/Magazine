using BL.ItemChanges.Load;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ItemChanges.Products
{
    public class LoadProductImage:ILoad
    {
        public void Loading(IUploadedFile uploadedFile)
        {
            uploadedFile.Path = @"\Files\" + uploadedFile.UploadedFile.FileName;
            using (var fileStream = new FileStream(uploadedFile.Root + uploadedFile.Path, FileMode.OpenOrCreate))
            {
                uploadedFile.UploadedFile.CopyTo(fileStream);
            }
        }
    }
}
