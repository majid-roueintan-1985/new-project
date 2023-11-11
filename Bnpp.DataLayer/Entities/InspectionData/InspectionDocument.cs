using Bnpp.DataLayer.Entities.OperationalDatas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities.InspectionData
{
    public class InspectionDocument
    {
        [Key]
        public int InspectionId { get; set; }

        [Required]
        public int TypeId { get; set; }


        public string Code { get; set; }
        public string FormName { get; set; }

        
        public string FormNo { get; set; }

        
        public string Description { get; set; }

        public string InspectionImage { get; set; }

        public string Filename { get; set; }

        public string DocumentName { get; set; }

        public DateTime InspectionDate { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsDelete { get; set; }

        [ForeignKey("TypeId")]
        public virtual InspectionType InspectionType { get; set; }


		[Required]
		public int MechanicalId { get; set; }

		[ForeignKey("MechanicalId")]
		public MechanicalEquipment MechanicalEquipment { get; set; }
	}
}
