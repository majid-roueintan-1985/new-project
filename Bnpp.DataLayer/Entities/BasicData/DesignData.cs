using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities.BasicData
{
    public class DesignData
    {
        [Key]
        public int DesignId { get; set; }


       
        public string ParameterName { get; set; }

       
        public string unit { get; set; }

      
        public string Value { get; set; }

       
        public string Description { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsDelete { get; set; }

		//Relations
		[Required]
		public int MechanicalId { get; set; }

		[ForeignKey("MechanicalId")]
		public MechanicalEquipment MechanicalEquipment { get; set; }
	}
}
