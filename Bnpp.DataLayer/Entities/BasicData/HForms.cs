﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities.BasicData
{
    public class HForms
    {
        [Key]
        public int HFormsId { get; set; }

        public string HFormsImage { get; set; }

       
        public string Code { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreateDate { get; set; }
       
        public string DocumentName { get; set; }
        public string Filename { get; set; }
		//Relations
		[Required]
		public int MechanicalId { get; set; }

		[ForeignKey("MechanicalId")]
		public MechanicalEquipment MechanicalEquipment { get; set; }
	}
}