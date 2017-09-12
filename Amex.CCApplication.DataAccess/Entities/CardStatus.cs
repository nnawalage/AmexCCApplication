﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amex.CCA.DataAccess.Entities
{
    public class CardStatus : AmexModelBase
    {
        [Key]
        public int CardStatusId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public virtual List<CreditCard> CreditCard { get; set; }
    }
}