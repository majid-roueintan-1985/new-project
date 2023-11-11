using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities.Maintenance
{
    public class SpareParts
    {
        [Key]
        public int SpareId { get; set; }

        [Required]
        public string PartName { get; set; }
        [Required]
        public string StandardNoofParts { get; set; }
        [Required]
        public string PartUnit { get; set; }
        [Required]
        public string RealNoofParts { get; set; }
        [Required]
        public string Designation { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsDelete { get; set; }

        [Required]
        public int MechanicalId { get; set; }

        [ForeignKey("MechanicalId")]
        public MechanicalEquipment MechanicalEquipment { get; set; }
    }
}
