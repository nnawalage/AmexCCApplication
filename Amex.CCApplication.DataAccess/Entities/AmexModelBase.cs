using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amex.CCA.DataAccess.Entities
{
    public class AmexModelBase
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedTime { get; set; }
        public string DeletedBy { get; set; }
        public DateTime DeletedTime { get; set; }

    }
}
