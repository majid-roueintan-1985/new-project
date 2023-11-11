using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities.AgeingDocuments
{
    public class Drawing
    {
        [Key]
        public int DrawingId { get; set; }

        public string DrawingImage { get; set; }

        [Required]
        public string Code { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreateDate { get; set; }
        [Required]
        public string DocumentName { get; set; }
        public string Filename { get; set; }

        [Required]
        public int MechanicalId { get; set; }

        [ForeignKey("MechanicalId")]
        public MechanicalEquipment MechanicalEquipment { get; set; }
    }
}
