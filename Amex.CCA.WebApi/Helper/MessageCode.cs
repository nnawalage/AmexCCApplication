using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amex.CCA.WebAPI.Helper
{
    public enum MessageCode : byte
    {
        Success = 0,
        Error = 1,
        Information = 2,
        Warning = 3
    }
}
