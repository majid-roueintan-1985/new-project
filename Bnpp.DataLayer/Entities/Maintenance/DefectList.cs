using Bnpp.DataLayer.Entities.OperationalDatas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities.Maintenance
{
    public class DefectList
    {
        [Key]
        public int DefectListId { get; set; }
        
        [Required]
        public string InstructionCorrection { get; set; }
        [Required]
        public string ControlCorrection { get; set; }
        [Required]
        public string CorrectionMethod { get; set; }
        [Required]
        public string ControlInstructionNo { get; set; }
        [Required]
        public string ControlResult { get; set; }
        [Required]
        public string ControlMethod { get; set; }

        [Required]
        public string PartorEquipment { get; set; }
        [Required]
        public string JournalNo { get; set; }
        [Required]
        public string NameofDefect { get; set; }

        public DateTime CorrectionDate { get; set; }

        public DateTime DetectionDate { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsDelete { get; set; }

        [Required]
        public int MechanicalId { get; set; }

        [ForeignKey("MechanicalId")]
        public MechanicalEquipment MechanicalEquipment { get; set; }
    }
}
