using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ItemChanges.Load
{
    public interface ILoad
    {
        void Loading(IUploadedFile uploadedFile);
    }
}
