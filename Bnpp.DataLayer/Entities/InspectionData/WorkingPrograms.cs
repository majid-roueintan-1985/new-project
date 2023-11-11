using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities.InspectionData
{
    public class WorkingPrograms
    {
        [Key]
        public int WorkingId { get; set; }


        [Required]
        public string WP { get; set; }

        [Required]
        public string TP { get; set; }



        [Required]
        public string EquipCode { get; set; }

        [Required]
        public string EquipName { get; set; }

        [Required]
        public string MeasuringType { get; set; }

        [Required]
        public string MaterialCompositions { get; set; }

        [Required]
        public string WeldNo { get; set; }

        [Required]
        public string ControlMethod { get; set; }



        [Required]
        public string ControlPercent { get; set; }


        [Required]
        public string ControlStandard { get; set; }

        [Required]
        public string QCStandard { get; set; }


        [Required]
        public string ControlResults { get; set; }
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
