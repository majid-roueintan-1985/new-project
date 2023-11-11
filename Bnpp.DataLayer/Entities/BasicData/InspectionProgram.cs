using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities.BasicData
{
    public class InspectionProgram
    {
        [Key]
        public int InspectionProgramId { get; set; }


       
        public string Code { get; set; }

       
        public string EquipmentDocument { get; set; }

       
        public string TestMethod { get; set; }

        
        public string TechnicalDocuments { get; set; }

       
        public string ScopeofInspection  { get; set; }

       
        public string PeriodofInspection { get; set; }

       
        public string CategoryofWeldedjoints { get; set; }

        
        public string Note { get; set; }

        public DateTime CreateDate { get; set; }
        public bool IsDelete { get; set; }
		//Relations

		[Required]
		public int MechanicalId { get; set; }

		[ForeignKey("MechanicalId")]
		public MechanicalEquipment MechanicalEquipment { get; set; }
	}
}
