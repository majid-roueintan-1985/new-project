﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities
{
    public class TypeofCable
    {
        [Key]
        public int ID { get; set; }

        public string TypeofCableTitle { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsDelete { get; set; }
    }
}
