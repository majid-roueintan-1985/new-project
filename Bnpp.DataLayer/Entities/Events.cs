using Bnpp.DataLayer.Entities.AgeingDocuments;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Entities
{
	public class Events
	{
        [Key]
        public int EventsId { get; set; }

        public string EventsImage { get; set; }

        public string Filename { get; set; }

        [Required]
        public string EventName { get; set; }

        [Required]
        public string EventLevel { get; set; }

        [Required]
        public string ReportNo { get; set; }

        [Required]
        public string ResponsibleUnit { get; set; }

        [Required]
        public string EventLocation { get; set; }

        public string RelatedAgeingMechanism { get; set; }

        public string Description { get; set; }

       

        //before
       

        public string BeforeOperatingModes { get; set; }

        public string BeforeHeatPower { get; set; }

        public string BeforeElectricalPower { get; set; }

        public string BeforeEffectiveWorkingDays { get; set; }

        public string BeforePressureWater { get; set; }

        public string BeforePressureinFirstCircuit { get; set; }

        public string BeforePressureinSecondCircuit { get; set; }

        public string BeforeVaccuminCondensor { get; set; }

        //after
        

        public string AfterOperatingModes { get; set; }

        public string AfterHeatPower { get; set; }

        public string AfterElectricalPower { get; set; }

        public string AfterEffectiveWorkingDays { get; set; }

        public string AfterPressureWater { get; set; }

        public string AfterPressureinFirstCircuit { get; set; }

        public string AfterPressureinSecondCircuit { get; set; }

        public string AfterVaccuminCondensor { get; set; }


        public DateTime EventDate { get; set; }



        public string EventTime { get; set; }

        public DateTime ReportDate { get; set; }


        
        public bool IsDelete { get; set; }

        public DateTime CreateDate { get; set; }

		[Required]
		public int MechanicalId { get; set; }

		[ForeignKey("MechanicalId")]
		public MechanicalEquipment MechanicalEquipment { get; set; }

	}
}
