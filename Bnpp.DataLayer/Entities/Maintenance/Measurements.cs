using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities.Maintenance
{
    public class Measurements
    {
        [Key]
        public int MeasurementId { get; set; }

        [Required]
        public string Typeofmeasurement { get; set; }

        [Required]
        public string Resultmeasurement { get; set; }

        [Required]
        public string Description { get; set; }


        public DateTime Dateofmeasurement { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsDelete { get; set; }


        [Required]
        public int MechanicalId { get; set; }

        [ForeignKey("MechanicalId")]
        public MechanicalEquipment MechanicalEquipment { get; set; }
    }
}
