using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities
{
    public class ExternalEvents
    {
        [Key]
        public int ExternalEventsId { get; set; }

        [Required]
        public string NPPName { get; set; }

        [Required]
        public string ReactorType { get; set; }
       
        [Required]
        public string ReportCode { get; set; }
        
        public string EventName { get; set; }

        public DateTime EventDate { get; set; }
       
        public DateTime ReportDate { get; set; }

        [Required]
        public string RelatedAgeingMechanism { get; set; }

        [Required]
        public string Description { get; set; }

        public string EventsImage { get; set; }

        public string Filename { get; set; }

        public bool IsDelete { get; set; }
        public DateTime CreateDate { get; set; }


		[Required]
		public int MechanicalId { get; set; }

		[ForeignKey("MechanicalId")]
		public MechanicalEquipment MechanicalEquipment { get; set; }
	}
}
