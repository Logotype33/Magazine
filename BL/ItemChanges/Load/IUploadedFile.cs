using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ItemChanges.Load
{
    public interface IUploadedFile
    {
        public IFormFile UploadedFile { get; set; }

        public string Root { get; set; }

        public string Path { get; set; }
    }
}
