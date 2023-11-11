using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities
{
    public class Commissioning
    {

        [Key]
        public int CommissioningId { get; set; }


        [Required]
        public string Parameter1 { get; set; }

        [Required]
        public string Parameter2 { get; set; }
        [Required]
        public string Parameter3 { get; set; }
        [Required]
        public string Parameter4 { get; set; }


        public DateTime CreateDate { get; set; }
        public bool IsDelete { get; set; }

		[Required]
		public int MechanicalId { get; set; }

		[ForeignKey("MechanicalId")]
		public MechanicalEquipment MechanicalEquipment { get; set; }
	}
}
