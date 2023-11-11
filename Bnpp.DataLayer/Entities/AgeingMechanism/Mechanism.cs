using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities.AgeingMechanism
{
    public class Mechanism
    {
        [Key]
        public int MechanismId { get; set; }


        [Required]
        public string DegradationMechanism { get; set; }

        [Required]
        public string Component { get; set; }

        [Required]
        public string Region { get; set; }

        [Required]
        public string CriticalPoint { get; set; }

        [Required]
        public string Consequences { get; set; }

        public DateTime CreateDate { get; set; }
        public bool IsDelete { get; set; }

		[Required]
		public int MechanicalId { get; set; }

		[ForeignKey("MechanicalId")]
		public MechanicalEquipment MechanicalEquipment { get; set; }
	}
}
