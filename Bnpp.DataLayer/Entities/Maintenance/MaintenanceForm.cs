using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities.Maintenance
{
    public class MaintenanceForm
    {
        [Key]
        public int MaintenanceFormId { get; set; }

        [Required]
        public string FormName { get; set; }

        [Required]
        public string FormNo { get; set; }

        [Required]
        public string Description { get; set; }

        public string MaintenanceFormImage { get; set; }

        public string Filename { get; set; }

        public string DocumentName { get; set; }

        public DateTime DateofMaintenance { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsDelete { get; set; }

		[Required]
		public int MechanicalId { get; set; }

		[ForeignKey("MechanicalId")]
		public MechanicalEquipment MechanicalEquipment { get; set; }

	}
}
