using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amex.CCA.BusinessServices.BusinessModels
{
    public class CardTypeEntity
    {
        public int CardTypeId { get; set; }
        
        public string Name { get; set; }

        public bool IsActive { get; set; }
    }
}
