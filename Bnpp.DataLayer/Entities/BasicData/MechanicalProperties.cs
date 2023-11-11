using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities.BasicData
{
    public class MechanicalProperties
    {
        [Key]
        public int MechanicalPropertiesId { get; set; }


        [Required]
        public string Temperature { get; set; }

        [Required]
        public string YoungModule { get; set; }

        [Required]
        public string YieldStrength { get; set; }

        [Required]
        public string UltimateStrength { get; set; }

        [Required]
        public string SpecificElongation { get; set; }
        [Required]
        public string ReductionArea { get; set; }
        [Required]
        public string ImpactToughness { get; set; }
        [Required]
        public string Hardness { get; set; }

        [Required]
        public int ComponentId { get; set; }

        [ForeignKey("ComponentId")]
        public Components Components { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDelete { get; set; }


        //[Required]
        //public int MechanicalId { get; set; }

        //[ForeignKey("MechanicalId")]
        //public MechanicalEquipment MechanicalEquipment { get; set; }
    }
}
