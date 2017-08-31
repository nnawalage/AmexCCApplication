﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amex.CCA.DataAccess.Entities
{
    public class Nationality:AmexModelBase
    {
        [Key]
        public int NationalityId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}