using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities.BasicData
{
    public class ChemicalNorms
    {
        [Key]
        public int ChemicalId { get; set; }


       
        public string IndexDescription { get; set; }

       
        public string Unit { get; set; }

      
        public string Value { get; set; }

       
        public string Limit { get; set; }


        public DateTime CreateDate { get; set; }
        public bool IsDelete { get; set; }

		//Relations
		[Required]
		public int MechanicalId { get; set; }

		[ForeignKey("MechanicalId")]
		public MechanicalEquipment MechanicalEquipment { get; set; }
	}
}
