using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities.OperationalDatas
{
    public class Operational
    {
        [Key]
        public int OperationalId { get; set; }
        public string SensorName { get; set; }
        public string ParameterName { get; set; }

        [Required]
        public int TypeId { get; set; }


        [Required]
        public string AKZ { get; set; }
        [Required]
        public string MinimumValue { get; set; }
        [Required]
        public string MaximumValue { get; set; }
        [Required]
        public string NormalValue { get; set; }
        [Required]
        public string TransientEvents { get; set; }
        [Required]
        public string Unit { get; set; }

        [ForeignKey("TypeId")]
        public virtual OperationalType OperationalType { get; set; }


        public DateTime CreateDate { get; set; }
        public bool IsDelete { get; set; }

		[Required]
		public int MechanicalId { get; set; }

		[ForeignKey("MechanicalId")]
		public MechanicalEquipment MechanicalEquipment { get; set; }

	}
}
