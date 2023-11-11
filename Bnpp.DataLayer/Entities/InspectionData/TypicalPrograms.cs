using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities.InspectionData
{
    public class TypicalPrograms
    {
        [Key]
        public int TypicalId { get; set; }


        [Required]
        public string TP { get; set; }

        [Required]
        public string EquipCode { get; set; }

        [Required]
        public string EquipName { get; set; }

        [Required]
        public string TestMethod { get; set; }

        [Required]
        public string TestStandard { get; set; }

        [Required]
        public string ControlPercent { get; set; }
        [Required]
        public string Period { get; set; }

        [Required]
        public string WeldType { get; set; }

        [Required]
        public string Remarks { get; set; }

       

        public DateTime CreateDate { get; set; }
        public bool IsDelete { get; set; }


		[Required]
		public int MechanicalId { get; set; }

		[ForeignKey("MechanicalId")]
		public MechanicalEquipment MechanicalEquipment { get; set; }
	}
}
